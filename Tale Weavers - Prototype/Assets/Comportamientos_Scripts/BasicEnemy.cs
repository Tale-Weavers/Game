using MBT;
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
    private MonoBehaviourTree BT;
    [SerializeField] private NavMeshAgent agent;
    

    [SerializeField] private bool playerSeen;
    [SerializeField] private bool alerted;
    [SerializeField] private bool distracted;
    [SerializeField] private bool goAwake;
    private GameObject player; 
    private GameObject distraction;
    private bool isPlaying;
    private Vector3 posToExplore;
    private bool lostVision;

    public bool GoAwake { get => goAwake; set => goAwake = value; }
    public bool PlayerSeen { get => playerSeen; set => playerSeen = value; }
    public bool Alerted { get => alerted; set => alerted = value; }
    public bool Distracted { get => distracted; set => distracted = value; }
    public GameObject PlayerPos { get => player; set => player = value; }
    public GameObject Distraction { get => distraction; set => distraction = value; }
    public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
    public bool LostVision { get => lostVision; set => lostVision = value; }



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

        BT = GetComponentInChildren<MonoBehaviourTree>();
        
    }


    // Update is called once per frame
    void Update()
    {     
        BT.Tick();
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
        agent.SetDestination(distraction.transform.position);
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0 && !IsPlaying)
        {
            distraction.GetComponent<ContinuousWoolBall>().NotifyEnemies(this);
            IsPlaying = true;
        }
    }

    public void Patrullar()
    {
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            GetNextWaypoint();
        }
    }
    public void Perseguir()
    {
        agent.SetDestination(player.transform.position);
    } 
    public void Investigar()
    {
        agent.SetDestination(posToExplore);
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            Alerted = false;
        }
    }
    public void Levantar()
    {
        //Debug.Log("get sopited");
        agent.SetDestination(distraction.transform.position);
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance < 1)
        {
            distraction.GetComponent<ContinuousWoolBall>().ForgetWoolball();
            distraction.SetActive(false);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RangeCollider"))
        {
            posToExplore = other.transform.parent.position;
            Alerted = true;
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
            PlayerPos = null;
            agent.ResetPath();
        }

    }
}
