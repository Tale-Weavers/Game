using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private Square[] wayPoints;
    private List<Vector3> waypointList = new();
    private Vector3 currentWaypoint;
    private int waypointCounter;
    [SerializeField] private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var direction in wayPoints)
        {
            Vector3 newDir = direction.transform.position;
            newDir.y += 1;
            waypointList.Add(newDir);
        }
        currentWaypoint = waypointList[0];
        waypointCounter = 1;

        
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        waypointCounter++;
        if (waypointCounter >= waypointList.Count)
        {
            waypointCounter = 0;
        }
        agent.SetDestination(waypointList[waypointCounter]);
    }
}
