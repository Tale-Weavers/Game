using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveEnemy : AEnemy
{
    public Square spawnPos;
    Vector3 spawnPosDir;
    public Vector3 investigationPoint;
    public State currentState;

    public enum State
    {
        Resting,
        Investigating,
        Fleeing,
        Returning
    }
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        spawnPosDir = new Vector3(spawnPos.transform.position.x, 0.665f, spawnPos.transform.position.z);
        transform.position = spawnPosDir;
        currentState = State.Resting;
        enemyType = TypeOfEnemy.DetectiveEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Resting:
                Debug.Log("mimimimimi");
                break;

            case State.Investigating:
                agent.SetDestination(investigationPoint);
                if ((transform.position - investigationPoint).magnitude < 1) currentState = State.Returning;
                break;

            case State.Fleeing:
                Vector3 awayFromPlayer = transform.position - player.transform.position;
                agent.SetDestination(transform.position + awayFromPlayer);
                FOV.viewAngle = 360;
                break;

            case State.Returning:
                FOV.viewAngle = 90;
                agent.SetDestination(spawnPosDir);
                if ((transform.position - spawnPosDir).magnitude < 1) currentState = State.Resting;
                break;
        }
    }

    public void SetInvestigationPoint(GameObject invPoint)
    {
        investigationPoint = invPoint.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RangeCollider"))
        {
            investigationPoint = other.transform.parent.position;
            currentState = State.Investigating;
        }
        else if (other.CompareTag("AttackCollider"))
        {
            if (currentState == State.Investigating || currentState == State.Resting)
            {
                gameObject.SetActive(false);
            }
        }


    }
}
