using MBT;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public abstract class Enemy : MoveableCharacter
{
    public MonoBehaviourTree BT;

    public Transform inspectorFacingDir;

    public bool knockOut = false;

    protected Vector3 facingDirection;

    [SerializeField] protected bool _playerSeen;

    [SerializeField] protected bool _alerted;

    [SerializeField] protected bool _distracted;

    [SerializeField] protected bool _goAwake;

    protected Square alertedTile;
    protected Square woolBallTile;
    protected WoolBall woolBall;

    [SerializeField] protected bool isBlinded;
    [SerializeField] protected int blindedCounter = 3;
    [SerializeField] protected AStarMind pathfinder;

    // Start is called before the first frame update
    protected void Start()
    {
        facingDirection = inspectorFacingDir.position;

        transform.rotation = Quaternion.LookRotation(facingDirection);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public abstract void StartAction();

    public void CheckVision()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, facingDirection * 3.5f, Color.red, 0.5f);

        if (Physics.Raycast(transform.position, facingDirection, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("Player") && !GameManager.instance.player._isHiding)
            {
                Debug.Log("Atrapada");
                GameManager.instance.player.Seen(true);
                GameManager.instance.NotifyEnemies(true);

                if (!CatchPlayer())
                {
                    ChasePlayer();
                    CatchPlayer();
                }
            }
            else if (hit.collider.CompareTag("WoolBall"))
            {
                Debug.Log($"Soy {gameObject.name} y he encontrado el ovillo");
                woolBall = hit.collider.GetComponent<WoolBall>();
                if (!woolBall.beingPlayed)
                {
                    _distracted = true;
                    woolBallTile = woolBall.tile;
                    woolBall.AddEnemy(this);
                    GameManager.instance.enemiesDistracted++;
                }
                else
                {
                    _goAwake = true;
                }
            }
        }
    }

    public bool PlayerHidCheck()
    {
        RaycastHit hit;
        bool playerHid = true;
        Debug.DrawRay(transform.position, facingDirection * 3.5f, Color.red, 0.5f);

        if (Physics.Raycast(transform.position, facingDirection, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                playerHid = false;
                Debug.Log("Atrapada");
                GameManager.instance.player.Seen(false);
            }
        }
        return playerHid;
    }

    public void PlayerSeen(bool seen)
    {
        _playerSeen = seen;
    }

    public void KnockEnemy()
    {
        knockOut = true;
        Debug.Log("Me mueroaaaaaa");
        transform.Rotate(90, 0, 0);
        currentPos.isWalkable = true;
        if (woolBall != null)
        {
            currentPos.containsWool = false;
            woolBall.ForgetWoolball();
            woolBall.gameObject.SetActive(false);
        }
        GetComponent<CapsuleCollider>().enabled = false;
        GameManager.instance.enemiesKnockedOut++;
        AudioManager.instance.Play("knockout");
    }

    protected void MoveTowards(Square destination)
    {
        if (!moveDone)
        {
            moveDone = true;
            Vector3 targetPosition = new Vector3(destination.transform.position.x, transform.position.y, destination.transform.position.z);
            facingDirection = targetPosition - transform.position;
            transform.position = targetPosition;
            currentPos.isWalkable = true;
            currentPos = destination.transform.GetComponent<Square>();
            currentPos.isWalkable = false;
            RotateEnemy();
            if (currentPos.containsWool)
            {
                woolBall = currentPos.wool;
                if (!woolBall.beingPlayed)
                {
                    _distracted = true;
                    woolBallTile = woolBall.tile;
                    woolBall.AddEnemy(this);
                    woolBall.beingPlayed = true;
                }
                else
                {
                    _goAwake = true;
                }
            }
        }
    }

    protected void ChasePlayer()
    {
        List<Square> list = new List<Square>();
        list = GridManager.instance.GetAdjacents(currentPos);
        Square optimalMovement = null;
        float distance = 999;

        foreach (Square square in list)
        {
            Vector3 aux = square.transform.position - GameManager.instance.player.transform.position;

            if (aux.magnitude < distance)
            {
                distance = aux.magnitude;
                optimalMovement = square;
            }

            List<Square> recursiveList = new();
            recursiveList = GridManager.instance.GetAdjacents(square);

            foreach (Square square2 in recursiveList)
            {
                Vector3 aux2 = square2.transform.position - GameManager.instance.player.transform.position;
                if (aux2.magnitude < distance)
                {
                    distance = aux2.magnitude;
                    optimalMovement = square;
                }
            }
        }

        MoveTowards(optimalMovement);
    }

    protected bool CatchPlayer()
    {
        Square playerPos;
        playerPos = GridManager.instance.LookForPlayer(currentPos);
        if (playerPos != null)
        {
            Debug.Log("Cachete");
            GameManager.instance.EndLevelLost();
            return true;
        }
        return false;
    }

    protected void RotateEnemy()
    {
        transform.rotation = Quaternion.LookRotation(facingDirection);
    }

    public void AlertEnemy(Square destination)
    {
        alertedTile = destination;
        _alerted = true;
        GameManager.instance.enemiesDistracted++;
    }

    public void EndExploring()
    {
        alertedTile = null;
        _alerted = false;
    }

    protected void ExploreSquawk(Square targetTile)
    {
        //List<Square> list = new List<Square>();
        //list = GridManager.instance.GetAdjacents(currentPos);
        //Square optimalMovement = null;
        //float distance = 999;

        //foreach (Square square in list)
        //{
        //    Vector3 aux = square.transform.position - targetTile.transform.position;

        //    if (aux.magnitude < distance)
        //    {
        //        distance = aux.magnitude;
        //        optimalMovement = square;
        //    }

        //    List<Square> recursiveList = new();
        //    recursiveList = GridManager.instance.GetAdjacents(square);

        //    foreach (Square square2 in recursiveList)
        //    {
        //        Vector3 aux2 = square2.transform.position - targetTile.transform.position;
        //        if (aux2.magnitude < distance)
        //        {
        //            distance = aux2.magnitude;
        //            optimalMovement = square;
        //        }
        //    }
        //}
        Square optimalMovement = pathfinder.GetNextMove(currentPos, targetTile);


        MoveTowards(optimalMovement);
    }

    public void GetBlinded(Vector3 lightDirection)
    {
        if (lightDirection + facingDirection == Vector3.zero) { isBlinded = true; GameManager.instance.enemiesDistracted++; }

    }

    protected void AwakeEnemies()
    {

        woolBall.ForgetWoolball();
        if (woolBall != null) woolBall.gameObject.SetActive(false);
        woolBall = null;

    }
    public void Perseguir()
    {
        CatchPlayer();
        ChasePlayer();
        CatchPlayer();
        CheckVision();
    }

    public void Jugar()
    {
        if (currentPos == woolBallTile)
        {
            Debug.Log("Estoy jugando");
            if (!AudioManager.instance.IsPlaying("eat") && !woolBall.isLaser) AudioManager.instance.Play("eat");
            woolBall.NotifyEnemies(this);
        }
        else
        {
            if (woolBallTile.containsWool) ExploreSquawk(woolBallTile);
            else
            {
                _distracted = false;
                CheckVision();
            }
        }
    }

    public void Investigar()
    {
        CheckVision();
        ExploreSquawk(alertedTile);
        if (alertedTile.isWalkable)
        {
            if (currentPos == alertedTile)
            {
                GameManager.instance.EnemyFinishedExploring();
            }
        }
        else
        {
            float distToGoal = (currentPos.transform.position - alertedTile.transform.position).magnitude;

            if (distToGoal <= 1.3)
            {
                GameManager.instance.EnemyFinishedExploring();
            }
        }
        CheckVision();
    }

    public void Levantar()
    {
        List<Square> neighbours = currentPos.SeeWool();
        if (neighbours.Contains(woolBallTile)) AwakeEnemies();
        else ExploreSquawk(woolBallTile);
    }

    public bool GetDistracted()
    {
        return _distracted;
    }
    public void SetDistracted(bool distracted)
    {
        _distracted = distracted;
    }

    public bool GetAlerted()
    {
        return _alerted;
    }
    public void SetAlerted(bool alerted)
    {
        _alerted = alerted;
    }

    public bool GetPlayerSeen()
    {
        return _playerSeen;
    }
    public void SetPlayerSeen(bool playerSeen)
    {
        _playerSeen = playerSeen;
    }

    public bool GetGoAwake()
    {
        return _goAwake;
    }
    public void SetGoAwake(bool goAwake)
    {
        _goAwake = goAwake;
    }

    public bool GetBlinded()
    {
        return isBlinded;
    }
    public void SetBlinded(bool blinded)
    {
        isBlinded = blinded;
    }

}