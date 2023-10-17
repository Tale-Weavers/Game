using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
    private int _rotationCounter = 1;

    public Transform[] directions;
    protected List<Vector3> realDirections = new();

    private void Start()
    {
        base.Start();
        foreach (var direction in directions)
        {
            realDirections.Add(direction.position);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    override public void StartAction()
    {
        if (!_playerSeen)
        {
            if (_alerted)
            {
                CheckVision();
                ExploreSquawk();
                if (currentPos == alertedTile)
                {
                    GameManager.instance.EnemyFinishedExploring();
                }
                CheckVision();
            }
            else
            {
                if (currentPos == initSpawn)
                {
                    CheckVision();
                    RotateVision();
                    CheckVision();
                }
                else
                {
                    CheckVision();
                    ReturnSpawn();
                    CheckVision();
                }
            }

        }
        else
        {
            CatchPlayer();
            ChasePlayer();
            CatchPlayer();
        }
    }

    private void RotateVision()
    {
        if (_rotationCounter >= realDirections.Count) _rotationCounter = 0;

        facingDirection = realDirections[_rotationCounter];
        _rotationCounter++;

        RotateEnemy();

    }

    private void ReturnSpawn()
    {
        List<Square> list = new List<Square>();
        list = GridManager.instance.GetAdjacents(currentPos);
        Square optimalMovement = null;
        float distance = 999;

        foreach (Square square in list)
        {
            Vector3 aux = square.transform.position - initSpawn.transform.position;

            if (square == initSpawn)
            {
                distance = 0;
                optimalMovement = square;
            }

            List<Square> recursiveList = new();
            recursiveList = GridManager.instance.GetAdjacents(square);

            foreach (Square square2 in recursiveList)
            {
                Vector3 aux2 = square2.transform.position - initSpawn.transform.position;
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
