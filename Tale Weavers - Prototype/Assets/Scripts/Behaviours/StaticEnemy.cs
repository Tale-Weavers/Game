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
        CheckVision();
        RotateVision();
    }
    
    private void RotateVision()
    {
        if(_rotationCounter>=realDirections.Count) _rotationCounter = 0;

        facingDirection = realDirections[_rotationCounter];
        _rotationCounter++;

    }
}
