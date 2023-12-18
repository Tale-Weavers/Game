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
    [SerializeField] protected bool lostVision;
    public TypeOfEnemy enemyType;
    protected MonoBehaviourTree BT;
    protected FieldOfView FOV;
    [SerializeField] protected bool playerSeen;
    public Sprite[] allBarks; //button - chase - clean - distract - flee - play - investigate - patrol - woolball
    protected Sprite currentBark;

    public bool LostVision { get => lostVision; set => lostVision = value; }
    public GameObject PlayerPos { get => player; set => player = value; }
    public ContinuousWoolBall Distraction { get => distraction; set => distraction = value; }
    public bool PlayerSeen { get => playerSeen; set => playerSeen = value; }

    public enum TypeOfEnemy
    {
        BasicEnemy,
        CleanerEnemy,
        SmallEnemy,
        DetectiveEnemy
    }

    protected void Update()
    {
        BT.Tick();
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = currentBark;
    }

    protected void Start()
    {
        FOV = GetComponent<FieldOfView>();
        currentBark = allBarks[5];
    }
}
