using MBT;
using System;
using System.Collections.Generic;
using UnityEngine;

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
        currentMaterial.color = Color.red;
        Debug.Log("Me mueroaaaaaa");
        transform.Rotate(90, 0, 0);
        currentPos.isWalkable = true;
        if(woolBall!=null) woolBall.gameObject.SetActive(false);
        GetComponent<CapsuleCollider>().enabled = false;
    }

    protected void MoveTowards(Square destination)
    {
        if (!moveDone)
        {
            Debug.Log("hola");
            moveDone = true;
            Vector3 targetPosition = new Vector3(destination.transform.position.x, transform.position.y, destination.transform.position.z);
            facingDirection = targetPosition - transform.position;
            transform.position = targetPosition;
            currentPos.isWalkable = true;
            currentPos = destination.transform.GetComponent<Square>();
            currentPos.isWalkable = false;
            RotateEnemy();
            if (_distracted && currentPos == woolBallTile) woolBall.beingPlayed = true;
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
    }

    public void EndExploring()
    {
        alertedTile = null;
        _alerted = false;
    }

    protected void ExploreSquawk(Square targetTile)
    {
        List<Square> list = new List<Square>();
        list = GridManager.instance.GetAdjacents(currentPos);
        Square optimalMovement = null;
        float distance = 999;

        foreach (Square square in list)
        {
            Vector3 aux = square.transform.position - targetTile.transform.position;

            if (aux.magnitude < distance)
            {
                distance = aux.magnitude;
                optimalMovement = square;
            }

            List<Square> recursiveList = new();
            recursiveList = GridManager.instance.GetAdjacents(square);

            foreach (Square square2 in recursiveList)
            {
                Vector3 aux2 = square2.transform.position - targetTile.transform.position;
                if (aux2.magnitude < distance)
                {
                    distance = aux2.magnitude;
                    optimalMovement = square;
                }
            }
        }

        MoveTowards(optimalMovement);
    }

    protected void AwakeEnemies()
    {

            woolBall.ForgetWoolball();
            if(woolBall != null) woolBall.gameObject.SetActive(false);
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
            woolBall.NotifyEnemies(this);
        }
        else ExploreSquawk(woolBallTile);
    }

    public void Investigar()
    {
        CheckVision();
        ExploreSquawk(alertedTile);
        if (currentPos == alertedTile)
        {
            GameManager.instance.EnemyFinishedExploring();
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

}