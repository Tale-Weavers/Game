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
        if (!isBlinded)
        {
            BT.Tick();
            BT.Restart();
        }
        else
        {
            blindedCounter--;
            if (blindedCounter == 0) { SetBlinded(false); blindedCounter = 3; }
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

        MoveTowards(pathfinder.GetNextMove(currentPos, initSpawn));
    }

    public void Vigilar()
    {
        if (currentPos == initSpawn)
        {
            CheckVision();
            if(_distracted) return;
            RotateVision();
            CheckVision();
        }
        else
        {
            CheckVision();
            if (_distracted) return;
            ReturnSpawn();
            CheckVision();
        }
    }
}
