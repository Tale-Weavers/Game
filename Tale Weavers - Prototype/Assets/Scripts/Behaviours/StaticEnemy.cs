using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
    private int _rotationCounter = 1;

    // Update is called once per frame
    void Update()
    {

    }

    override public void StartAction()
    {
        if (!_playerSeen)
        {
            CheckVision();
            RotateVision();
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

    }

    
}
