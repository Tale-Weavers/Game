using System.Collections.Generic;
using UnityEngine;

public class MoveableEnemy : Enemy
{
    [SerializeField] private Square[] wayPoints;
    private Square currentWaypoint;
    private List<Square> waypointList = new();
    private int waypointCounter;
    private bool onWaypoint = false;

    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        foreach (var direction in wayPoints)
        {
            waypointList.Add(direction);
        }
        currentWaypoint = wayPoints[0];
        waypointCounter = 1;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public override void StartAction()
    {
        if (!_playerSeen)
        {
            if (_distracted)
            {
                if (currentPos == woolBallTile)
                {
                    Debug.Log("Estoy jugando");
                    
                }
                else if (woolBall.beingPlayed)
                {
                    List<Square> neighbours = currentPos.SeeWool();
                    if (neighbours.Contains(woolBallTile)) AwakeEnemies();
                    else ExploreSquawk(woolBallTile);
                }
                else ExploreSquawk(woolBallTile);
            }

            else
            {
                if (_alerted)
                {
                    CheckVision();
                    ExploreSquawk(alertedTile);
                    if (currentPos == alertedTile)
                    {
                        GameManager.instance.EnemyFinishedExploring();
                    }
                    CheckVision();
                }
                else
                {
                    CheckVision();
                    if (currentWaypoint == currentPos)
                    {
                        SelectWaypoint();
                    }
                    if (onWaypoint)
                    {
                        onWaypoint = false;
                        LookNextWaypoint();
                    }
                    else
                    {
                        MoveToWaypoint();
                    }
                    CheckVision();
                }
            }
        }
        else
        {
            if (_distracted)
            {

                if (currentPos == woolBallTile)
                {
                    Debug.Log("Estoy jugando");
                }
                else ExploreSquawk(woolBallTile);
            }
            else
            {
                CatchPlayer();
                ChasePlayer();
                CatchPlayer();
                CheckVision();
            }
        }
    }

    private void MoveToWaypoint()
    {
        List<Square> list = new List<Square>();
        list = GridManager.instance.GetAdjacents(currentPos);
        Square optimalMovement = null;
        float distance = 999;

        foreach (Square square in list)
        {
            Vector3 aux = square.transform.position - currentWaypoint.transform.position;

            if (aux.magnitude < distance)
            {
                distance = aux.magnitude;
                optimalMovement = square;
            }

            List<Square> recursiveList = new();
            recursiveList = GridManager.instance.GetAdjacents(square);

            foreach (Square square2 in recursiveList)
            {
                Vector3 aux2 = square2.transform.position - currentWaypoint.transform.position;
                if (aux2.magnitude < distance)
                {
                    distance = aux2.magnitude;
                    optimalMovement = square;
                }
            }
        }

        MoveTowards(optimalMovement);

        if (currentWaypoint == currentPos)
        {
            onWaypoint = true;
        }
    }

    private void SelectWaypoint()
    {
        if (waypointCounter >= waypointList.Count) waypointCounter = 0;

        currentWaypoint = waypointList[waypointCounter];
        waypointCounter++;
    }

    private void LookNextWaypoint()
    {
        Vector3 targetPosition = new Vector3(currentWaypoint.transform.position.x, transform.position.y, currentWaypoint.transform.position.z);
        facingDirection = targetPosition - transform.position;
        facingDirection.Normalize();
        RotateEnemy();
    }
}