using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolBall : MonoBehaviour
{
    public Square tile;
    public bool beingPlayed = false;
    public bool isLaser;
    public List<Enemy> enemyList = new();
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        tile.containsWool = true;
        tile.wool = GetComponent<WoolBall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void NotifyEnemies(Enemy enemy)
    {
        foreach(Enemy enemigo in enemyList)
        {
            if (enemy != enemigo) { enemigo.SetDistracted(false); enemigo.SetGoAwake(true); }
        }
    }

    public void ForgetWoolball()
    {
       foreach (Enemy enemy in enemyList)
        {
            enemy.ForgetWoolball();
            enemy.SetDistracted(false);
            enemy.SetGoAwake(false);
        }
    }
}
