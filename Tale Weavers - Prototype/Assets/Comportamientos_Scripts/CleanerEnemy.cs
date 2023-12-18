using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CleanerEnemy : AEnemy
{
    Square SpawnPos;
    public bool playerInSight;
    float cleanupProgress;
    Vector3 spawnPosVector;

    public bool PlayerInSight { get => playerInSight; set => playerInSight = value; }

    public void CleanerEnemySetup(GameObject woolball, Square pos)
    {
        SpawnPos = pos;
        distraction = woolball.GetComponent<ContinuousWoolBall>();
        transform.position = new Vector3(SpawnPos.transform.position.x, 0.655f, SpawnPos.transform.position.z);
        
        cleanupProgress = 0;
        currentBark = allBarks[2];
    }

    void Start()
    {
        base.Start();
        BT = GetComponentInChildren<MonoBehaviourTree>();
        enemyType = TypeOfEnemy.CleanerEnemy;
        FOV = GetComponent<FieldOfView>(); 
        spawnPosVector = transform.position;
    }

    public void SetCheckpoint()
    {
        if (distraction == null)
        {
            agent.SetDestination(spawnPosVector);
            currentBark = allBarks[5];
        }
        else {agent.SetDestination(distraction.transform.position); currentBark = allBarks[2]; }
    }

    public bool LookAround()
    {
        if (PlayerInSight == false) FOV.viewAngle = 90; 
        return PlayerInSight;
    }

    public void Cleanup()
    {
        currentBark = allBarks[2];
        if (distraction == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            distraction.ForgetWoolball();
        }
        cleanupProgress += Time.deltaTime;
        if (cleanupProgress > 3)
        {

            distraction.gameObject.SetActive(false);
            distraction = null;
        }
    }

    public void Flee()
    {
        currentBark = allBarks[4];
        Debug.Log("ay que miedo");
        Vector3 awayFromPlayer = transform.position - player.transform.position;
        agent.SetDestination(transform.position + awayFromPlayer);
        FOV.viewAngle = 360;
    }

    public float CheckDistToDistraction()
    {
        float dist;
        if(distraction != null) dist = (transform.position - distraction.transform.position).magnitude;
        else dist = (transform.position - spawnPosVector).magnitude;

        return dist;
    }
}
