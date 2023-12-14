using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AEnemy : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] protected ContinuousWoolBall distraction;
    [SerializeField] protected NavMeshAgent agent;
    protected bool lostVision;
    public TypeOfEnemy enemyType;
    protected MonoBehaviourTree BT;

    public bool LostVision { get => lostVision; set => lostVision = value; }
    public GameObject PlayerPos { get => player; set => player = value; }
    public ContinuousWoolBall Distraction { get => distraction; set => distraction = value; }

    public enum TypeOfEnemy
    {
        BasicEnemy,
        CleanerEnemy,
        SmallEnemy
    }

    protected void Update()
    {
        BT.Tick();
    }
}
