using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MoveableCharacter
{
    public Transform inspectorFacingDir;

    public bool knockOut = false;

    protected Vector3 facingDirection;

    [SerializeField] protected bool _playerSeen;

    [SerializeField] protected bool _alerted;

    protected Square alertedTile;

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
        GetComponent<CapsuleCollider>().enabled = false;
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
            GameManager.instance.RestartLevel();
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

    protected void ExploreSquawk()
    {
        List<Square> list = new List<Square>();
        list = GridManager.instance.GetAdjacents(currentPos);
        Square optimalMovement = null;
        float distance = 999;

        foreach (Square square in list)
        {
            Vector3 aux = square.transform.position - alertedTile.transform.position;

            if (aux.magnitude < distance)
            {
                distance = aux.magnitude;
                optimalMovement = square;
            }

            List<Square> recursiveList = new();
            recursiveList = GridManager.instance.GetAdjacents(square);

            foreach (Square square2 in recursiveList)
            {
                Vector3 aux2 = square2.transform.position - alertedTile.transform.position;
                if (aux2.magnitude < distance)
                {
                    distance = aux2.magnitude;
                    optimalMovement = square;
                }
            }
        }

        MoveTowards(optimalMovement);
    }
}