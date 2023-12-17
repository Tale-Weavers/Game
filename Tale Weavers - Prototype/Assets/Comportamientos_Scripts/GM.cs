using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM instance;

    public BasicEnemy[] listOfEnemies;
    public DetectiveEnemy[] listOfDetectives;
    public Square[] cleanerSpawnPoints;
    public PlayerBehaviour player;
    public ContinuousWoolBall[] listOfContinuousWoolBalls;
    public GameObject[] buttons;
    
    public Square exitSquare;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
 
    }


    public void NotifyEnemies(bool seen)
    {
        foreach (BasicEnemy enemy in listOfEnemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.PlayerFound(player.gameObject, seen);
                if (!seen) enemy.First = false;
            }
        }
    }
    public void CheckLostVision()
    {
        Debug.Log("a ver si te veo");
        bool allLostVision = true;
        foreach (BasicEnemy enemy in listOfEnemies)
        {
            if (!enemy.LostVision&&!enemy.Distracted&&enemy.gameObject.activeSelf)
            {
                allLostVision = false;
            }
           
        }
        if (allLostVision)
        {
            Debug.Log("Ya no te veo");
            NotifyEnemies(false);
            foreach(DetectiveEnemy enemy in listOfDetectives)
            {
                enemy.SetInvestigationPoint(player.gameObject);
                enemy.currentState = DetectiveEnemy.State.Investigating;
                
            }

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
