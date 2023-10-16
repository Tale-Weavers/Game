using System.Collections.Generic;
using UnityEngine;

public class MoveableEnemy : Enemy
{
    [SerializeField] private Square[] wayPoints;
    private Square currentWaypoint;
    private List<Square> waypointList = new();
    private int waypointCounter;

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
            CheckVision();
            if (currentWaypoint == currentPos)
            {
                SelectWaypoint2();
            }
            MoveToWaypoint();
            CheckVision();
        }
        else
        {
            CatchPlayer();
            ChasePlayer();
            CatchPlayer();
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
    }

    private void SelectWaypoint()
    {
        if (waypointCounter >= wayPoints.Length-1) waypointCounter = 0;
        Debug.Log(waypointCounter);
        Debug.Log(wayPoints.Length);
        waypointCounter++;
        currentWaypoint = wayPoints[waypointCounter];

    }

    private void SelectWaypoint2()
    {
        if (waypointCounter >= waypointList.Count) waypointCounter = 0;

        currentWaypoint = waypointList[waypointCounter];
        waypointCounter++;

    }
}