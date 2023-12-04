using MBT;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public abstract class Enemy : MoveableCharacter
{
    public MonoBehaviourTree BT;

    public Transform inspectorFacingDir;

    public bool knockOut = false;

    protected Vector3 facingDirection;
    protected Vector3 oldFacingDirection;

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


    [SerializeField] private VisionCone visionCone;


    [SerializeField] protected const float MOV_SPEED = 0.05f;

    protected Animator animator;
    protected Vector3 target;
    protected Vector3 playerTarget;
    protected bool moving;
    protected bool jumping;
    protected bool playerCaught;

    // Start is called before the first frame update
    protected void Start()
    {
        

        facingDirection = inspectorFacingDir.position;

        transform.rotation = Quaternion.LookRotation(facingDirection);
        animator = GetComponentInChildren<Animator>();
        transform.position = new Vector3(currentPos.transform.position.x, 1, currentPos.transform.position.z);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, MOV_SPEED);
            if ((transform.position - target).magnitude <= 0.01) 
            {
                moving = false;
                animator.SetTrigger("Idle");
                if (jumping) { animator.SetTrigger("Jump"); facingDirection = playerTarget-transform.position; RotateEnemy(); }

                else if (_distracted)
                {
                    if (woolBall.isLaser && currentPos == woolBallTile)
                    {
                        animator.SetTrigger("Play");
                    }
                    else if(!woolBall.isLaser && currentPos == woolBallTile)
                    {
                        animator.SetTrigger("Eat");
                    }
                }
                else if(!_distracted && !isBlinded)
                {
                    CheckVision();
                }
                
            }
        }
        else if (jumping)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget, MOV_SPEED);
            if ((transform.position - playerTarget).magnitude <= 0.01) 
            {
                jumping = false;
                
            }
        }
    }

    public abstract void StartAction();

    public void CheckVision()
    {

        RaycastHit hit;

        Debug.DrawRay(transform.position, facingDirection * 3.5f, Color.red, 0.5f);

        if (Physics.Raycast(transform.position, facingDirection, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("Player") && !GameManager.instance.player.IsHiding)
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
                //Debug.Log($"Soy {gameObject.name} y he encontrado el ovillo");
                woolBall = hit.collider.GetComponent<WoolBall>();
                if (!woolBall.beingPlayed)
                {
                    SetDistracted(true);
                    woolBallTile = woolBall.tile;
                    woolBall.AddEnemy(this);
                    GameManager.instance.enemiesDistracted++;
                }
                else
                {
                    _goAwake = true;
                }
                if (!moveDone)
                {
                    ExploreSquawk(woolBallTile);
                }
            }
        }
    }

    public bool PlayerHidCheck()
    {
        RaycastHit hit;
        bool playerHid = true;

        if (Physics.Raycast(transform.position, facingDirection, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                playerHid = false;
                //Debug.Log("Atrapada");
                GameManager.instance.player.Seen(true);
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
        //Debug.Log("Me mueroaaaaaa");
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
        gameObject.SetActive(false);
    }

    protected void MoveTowards(Square destination)
    {

        animator.SetTrigger("Step");
        if (!moveDone)
        {
            if(destination == null)
            {
                destination = GameManager.instance.player.currentPos;
                destination = pathfinder.GetNextMove(currentPos, destination);
            }
            moveDone = true;
            target = new Vector3(destination.transform.position.x, transform.position.y, destination.transform.position.z);
            facingDirection = target - transform.position;
            moving = true;
            currentPos.isWalkable = true;
            currentPos = destination.transform.GetComponent<Square>();
            currentPos.isWalkable = false;
            RotateEnemy();
            if (currentPos.containsWool)
            {
                woolBall = currentPos.wool;
                if (!woolBall.beingPlayed)
                {
                    SetDistracted(true);
                    woolBallTile = woolBall.tile;
                    woolBall.AddEnemy(this);
                    woolBall.beingPlayed = true;
                    woolBall.NotifyEnemies(this);
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
            playerCaught = true;
            StartCoroutine(DelayJump());
            playerTarget = new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z);
            jumping = true;
            //animator.SetTrigger("Jump");
            //Debug.Log("Cachete");
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

        Square optimalMovement = pathfinder.GetNextMove(currentPos, targetTile);


        MoveTowards(optimalMovement);
    }

    public void GetBlinded(Vector3 lightDirection)
    {
        if (lightDirection + facingDirection == Vector3.zero) { SetBlinded(true); GameManager.instance.enemiesDistracted++; }

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
        if (!playerCaught)
        {
            ChasePlayer();
            CatchPlayer();
            CheckVision();
        }
    }

    public void Jugar()
    {
        if (currentPos == woolBallTile)
        {
            //Debug.Log("Estoy jugando");
            
            if (!AudioManager.instance.IsPlaying("eat") && !woolBall.isLaser) AudioManager.instance.Play("eat");
            else if (!AudioManager.instance.IsPlaying("eat") && woolBall.isLaser) AudioManager.instance.Play("ronroneo");
            woolBall.NotifyEnemies(this);
        }
        else
        {
            if (woolBallTile.containsWool) 
            { 
                ExploreSquawk(woolBallTile);
                if (currentPos == woolBallTile)
                {
                    //Debug.Log("Estoy jugando");

                    if (!AudioManager.instance.IsPlaying("eat") && !woolBall.isLaser) AudioManager.instance.Play("eat");
                    else if (!AudioManager.instance.IsPlaying("eat") && woolBall.isLaser) AudioManager.instance.Play("ronroneo");
                }
            }
            else
            {
                SetDistracted(false);
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
        if (!distracted) { animator.SetTrigger("Idle"); visionCone.gameObject.SetActive(true); }
        else visionCone.gameObject.SetActive(false);
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
        if (!blinded) { animator.SetTrigger("Idle"); visionCone.gameObject.SetActive(true); }
        else visionCone.gameObject.SetActive(false);
    }


    public void UpdateVisionCone()
    {
        visionCone.DrawVisionCone();
    }


    public void ForgetWoolball()
    {
        animator.SetTrigger("Idle");
    }
    private IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(0.65f);
        jumping = true;
    }

}