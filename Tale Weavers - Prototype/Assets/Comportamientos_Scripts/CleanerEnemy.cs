using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CleanerEnemy : AEnemy
{
    [SerializeField] Square SpawnPos;
    public bool playerInSight;
    float cleanupProgress;
    FieldOfView FOV;

    public bool PlayerInSight { get => playerInSight; set => playerInSight = value; }

    CleanerEnemy(GameObject woolball)
    {
        distraction = woolball;
        transform.position = new Vector3(SpawnPos.transform.position.x, 0.655f, SpawnPos.transform.position.z);
    }

    void Start()
    {
        BT = GetComponentInChildren<MonoBehaviourTree>();
        enemyType = TypeOfEnemy.CleanerEnemy;
        FOV = GetComponent<FieldOfView>();
    }

    public void SetCheckpoint()
    {
        agent.SetDestination(distraction.transform.position);
    }

    public bool LookAround()
    {
        if (PlayerInSight == false) FOV.viewAngle = 90; 
        return PlayerInSight;
    }

    void Cleanup()
    {

    }

    public void Flee()
    {
        Debug.Log("ay que miedo");
        Vector3 awayFromPlayer = transform.position - player.transform.position;
        agent.SetDestination(transform.position + awayFromPlayer);
        FOV.viewAngle = 360;
    }
}
