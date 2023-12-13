using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousWoolBall : MonoBehaviour
{
    public bool beingPlayed = false;
    public bool isLaser;
    public List<BasicEnemy> enemyList = new();


    public void AddEnemy(BasicEnemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void NotifyEnemies(BasicEnemy enemy)
    {
        foreach (BasicEnemy enemigo in enemyList)
        {
            if (enemy != enemigo) 
            { 
                enemigo.Distracted = false; enemigo.GoAwake = true; 
            }
        }
    }

    public void ForgetWoolball()
    {
        foreach (BasicEnemy enemy in enemyList)
        {
            enemy.Distracted = false; enemy.GoAwake = false;
        }
    }
}
