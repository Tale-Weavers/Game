using BehaviourAPI.Core;
using BehaviourAPI.Core.Actions;
using BehaviourAPI.UnityToolkit.GUIDesigner.Runtime;
using BehaviourAPI.UtilitySystems;
using MBTExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BuddyAlly : MonoBehaviour
{

    public UtilitySystem utilitySystem;
    AEnemy closestEnemy;
    ContinuousWoolBall closestItem;
    GameObject closestButton;
    PlayerBehaviour pb;
    public List<BasicEnemy> distractedEnemies = new List<BasicEnemy>();

    [Header("Variables")]
    public float distanciaSalida;
    public float enemigosCercanos;
    public float objetosCercanos;
    public float botonesCercanos;

    [Header("Limites")]
    public float maxDistanciaSalida;
    public float maxEnemigosCercanos;
    public float maxObjetosCercanos;
    public float maxBotonesCercanos;

    private List<UtilityAction> actionList = new();

    private bool hasItem;
    public bool buttonPressed;

    NavMeshAgent agent;
    // Start is called before the first frame update

    public BSRuntimeDebugger _bsRuntimeDebugger;

    private bool coroutineLaunched;

    public Sprite[] allBarks; //button - chase - clean - distract - flee - play - investigate - patrol - woolball
    protected Sprite currentBark;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        if(utilitySystem == null)
        {
            Generate();
        }

        UpdateActions();
    }
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(utilitySystem != null)
        {

            utilitySystem.Update();
        }
        
        spriteRenderer.sprite = currentBark;
    }

    void Generate()
    {
        pb = GetComponentInParent<PlayerBehaviour>();



        utilitySystem = new UtilitySystem();
        

        VariableFactor distanciaALaSalida = utilitySystem.CreateVariable("distanciaSalida",() => distanciaSalida, 0f, maxDistanciaSalida);


        VariableFactor enemigosCerca = utilitySystem.CreateVariable("enemigosCerca",() => enemigosCercanos, 0f, maxEnemigosCercanos);
        

        VariableFactor botonCerca = utilitySystem.CreateVariable("botonCerca",() => botonesCercanos, 0f, maxBotonesCercanos);


        VariableFactor objetosCerca = utilitySystem.CreateVariable("objetosCerca",() => objetosCercanos, 0f, maxObjetosCercanos);

        SigmoidCurveFactor curve1 = utilitySystem.CreateCurve<SigmoidCurveFactor>("curve1",distanciaALaSalida);
        curve1.GrownRate = -5f;
        


        SigmoidCurveFactor curve2 = utilitySystem.CreateCurve<SigmoidCurveFactor>("curve2", enemigosCerca);
        curve2.GrownRate = -5f;

        PointedCurveFactor curve3 = utilitySystem.CreateCurve<PointedCurveFactor>("curve3", enemigosCerca);
        curve3.Points = new List<CurvePoint>()
        {
            new CurvePoint(0,0),
            new CurvePoint(0.5f, 1),
            new CurvePoint(1, 0)
        };

        SigmoidCurveFactor curve4 = utilitySystem.CreateCurve<SigmoidCurveFactor>("curve4", enemigosCerca);
        curve4.GrownRate = -5f;


        LinearCurveFactor curve5 = utilitySystem.CreateCurve<LinearCurveFactor>("curve5", objetosCerca);
        curve5.Slope = -1;
        curve5.YIntercept = 1;
   
        LinearCurveFactor curve6 = utilitySystem.CreateCurve<LinearCurveFactor>("curve6", botonCerca);
        curve6.Slope = -1;
        curve6.YIntercept = 1;

        WeightedFusionFactor w1 = utilitySystem.CreateFusion<WeightedFusionFactor>("weight1",curve1,curve2);
        w1.Weights = new float[] { 0.5f, 0.5f };

        WeightedFusionFactor w2 = utilitySystem.CreateFusion<WeightedFusionFactor>("weight2", curve3, curve5);
        w2.Weights = new float[] { 0.5f, 0.5f };

        WeightedFusionFactor w3 = utilitySystem.CreateFusion<WeightedFusionFactor>("weight3",curve1, curve4,curve6);
        w3.Weights = new float[] { 1/3f, 1/3f,1/3f };
        
        FunctionalAction distraer = new FunctionalAction(ChaseUpdate);
        FunctionalAction traerObjeto = new FunctionalAction(BringObjectUpdate);
        FunctionalAction apretarBoton = new FunctionalAction(PushButtonUpdate);

        

        UtilityAction utility1 = utilitySystem.CreateAction("distraer",w1, distraer);
        UtilityAction utility2 = utilitySystem.CreateAction("traerObjeto",w2, traerObjeto);
        UtilityAction utility3 = utilitySystem.CreateAction("apretarBoton",w3, apretarBoton);

        actionList.Add(utility1);
        actionList.Add(utility2);
        actionList.Add(utility3);



        utilitySystem.Start();
    }

    public void UpdateActions()
    {


        distanciaSalida = (GM.instance.exitSquare.transform.position - pb.transform.position).magnitude;

        float distancia = 1000000;


        foreach(AEnemy enemy in GM.instance.listOfEnemies)
        {
            if ((enemy.transform.position - pb.transform.position).magnitude < distancia && enemy.gameObject.activeSelf && !enemy.GetComponent<BasicEnemy>().Distracted)
            {
                closestEnemy = enemy;
                distancia = (enemy.transform.position - pb.transform.position).magnitude;
            }
        }
        enemigosCercanos = distancia;

        
        distancia = 1000000;


        foreach (ContinuousWoolBall item in GM.instance.listOfContinuousWoolBalls)
        {
            if ((item.transform.position - pb.transform.position).magnitude < distancia && item.gameObject.activeSelf)
            {
                closestItem = item;
                distancia = (item.transform.position - pb.transform.position).magnitude;
            }
        }
        objetosCercanos = distancia;

        distancia = 1000000;

        foreach (GameObject button in GM.instance.buttons)
        {
            if ((button.transform.position - pb.transform.position).magnitude < distancia && button.activeSelf)
            {
                closestButton = button;
                distancia = (button.transform.position - pb.transform.position).magnitude;
            }
        }
        botonesCercanos = distancia;

        foreach (UtilityAction i in actionList)
        {

            i.UpdateUtility();
     
        }

        _bsRuntimeDebugger.RegisterGraph(utilitySystem, "Utility System");
    }

    public Status ChaseUpdate()
    {
        currentBark = allBarks[3];
        if(!coroutineLaunched)
        {
            StartCoroutine(EndChasing());
            coroutineLaunched = true;
        }
        Vector3 targetPosition = closestEnemy.transform.position;
        targetPosition += closestEnemy.transform.forward*2;
        agent.SetDestination(targetPosition);
        return Status.Running;
    }


    public Status BringObjectUpdate()
    {
        currentBark = allBarks[8];
        if (!hasItem)
        {
            agent.SetDestination(closestItem.transform.position);
            if ((closestItem.transform.position - transform.position).magnitude < 1f)
            {
                hasItem = true;
                closestItem.gameObject.SetActive(false);
            }
        }
        else
        {
            agent.SetDestination(pb.transform.position);
            if ((pb.transform.position - transform.position).magnitude < 1f)
            {
                hasItem = false;
                pb.GiveWollball(closestItem);
                gameObject.SetActive(false);
            }
        }

        return Status.Running;
    }


    public Status PushButtonUpdate()
    {
        currentBark = allBarks[0];
        if (!buttonPressed)
        {
            agent.SetDestination(closestButton.transform.position);
        }
        else
        {
            agent.SetDestination(pb.transform.position);
            if ((pb.transform.position - transform.position).magnitude < 1f)
            {
                buttonPressed = false;
                gameObject.SetActive(false);
            }
        }
        return Status.Running;
    }

    IEnumerator EndChasing()
    {
        yield return new WaitForSeconds(10);
        transform.position = pb.transform.position + pb.transform.forward;
        gameObject.SetActive(false);
        coroutineLaunched = false;
    }

    private void OnDisable()
    {
        foreach (BasicEnemy enemy in distractedEnemies)
        {
            enemy.Distracted = false;
            enemy.DistractedByBuddy = false;
        }
    }
}
