using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM instance;

    public BasicEnemy[] listOfEnemies;
    public PlayerBehaviour player;

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
            enemy.PlayerFound(player.gameObject,seen);
        }
    }
    public void CheckLostVision()
    {
        bool allLostVision = true;
        foreach (BasicEnemy enemy in listOfEnemies)
        {
            if (!enemy.LostVision&&!enemy.Distracted)
            {
                allLostVision = false;
            }
           
        }
        if (allLostVision)
        {
            NotifyEnemies(false);
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
