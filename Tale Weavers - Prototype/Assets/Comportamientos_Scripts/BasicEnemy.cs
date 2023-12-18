using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : AEnemy
{
    [SerializeField] private Square[] wayPoints;
    private List<Vector3> waypointList = new();
    private Vector3 currentWaypoint;
    private int waypointCounter;
    protected bool distractedByBuddy;
    public GameObject buddy;


    [SerializeField] private bool alerted;
    [SerializeField] private bool distracted;
    [SerializeField] private bool goAwake;
    private bool isPlaying;
    private Vector3 posToExplore;
    private bool first;

    public bool GoAwake { get => goAwake; set => goAwake = value; }
    public bool Alerted { get => alerted; set => alerted = value; }
    public bool Distracted { get => distracted; set => distracted = value; }
    public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
    public bool First { get => first; set => first = value; }
    public bool DistractedByBuddy { get => distractedByBuddy; set => distractedByBuddy = value; }




    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        foreach (var direction in wayPoints)
        {
            Vector3 newDir = direction.transform.position;
            newDir.y += 1;
            waypointList.Add(newDir);
        }
        currentWaypoint = waypointList[0];
        waypointCounter = 1;

        BT = GetComponentInChildren<MonoBehaviourTree>();
        enemyType = TypeOfEnemy.BasicEnemy;

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

    public void Jugar()
    {
        if (!distractedByBuddy)
        {
            agent.SetDestination(distraction.transform.position);
            float dist = agent.remainingDistance;
            if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0 && !IsPlaying)
            {
                distraction.GetComponent<ContinuousWoolBall>().NotifyEnemies(this);
                IsPlaying = true;
            }
            currentBark = allBarks[5];
        }
        else
        {
            agent.SetDestination(buddy.transform.position);
            currentBark = allBarks[1];
        }
    }

    public void Patrullar()
    {
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            GetNextWaypoint();
        }
        currentBark = allBarks[7];
    }
    public void Perseguir()
    {
        agent.SetDestination(player.transform.position);
        currentBark = allBarks[1];
    } 
    public void Investigar()
    {
        agent.SetDestination(posToExplore);
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            Alerted = false;
        }
        currentBark = allBarks[6];
    }
    public void Levantar()
    {
        //Debug.Log("get sopited");
        agent.SetDestination(distraction.transform.position);
        float dist = (distraction.transform.position - transform.position).magnitude;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && dist < 1)
        {
            distraction.GetComponent<ContinuousWoolBall>().ForgetWoolball();
            distraction.gameObject.SetActive(false);
        }
        currentBark = allBarks[5];
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RangeCollider"))
        {
            posToExplore = other.transform.parent.position;
            Alerted = true;
        }
        else if (other.CompareTag("AttackCollider"))
        {
            if (!playerSeen)
            {
                gameObject.SetActive(false);
            }
        }

        
    }


    public void ForgetRoute()
    {
        agent.ResetPath();
    }

    public void PlayerFound(GameObject player,bool seen)
    {
        if (seen)
        {
            PlayerSeen = true;
            PlayerPos = player;
        }
        else
        {
            PlayerSeen = false;
            agent.ResetPath();
        }

    }
}
