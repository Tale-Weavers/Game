using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousWoolBall : MonoBehaviour
{
    public bool beingPlayed = false;
    public bool isLaser;
    public List<AEnemy> enemyList = new();


    public void AddEnemy(AEnemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void NotifyEnemies(AEnemy enemy)
    {
        foreach (AEnemy enemigo in enemyList)
        {
            if (enemy != enemigo) 
            {
                BasicEnemy newEnemy = enemigo.GetComponent<BasicEnemy>();
                newEnemy.Distracted = false; newEnemy.GoAwake = true; 
            }
        }
    }

    public void ForgetWoolball()
    {
        foreach (AEnemy enemy in enemyList)
        {
            BasicEnemy newEnemy = enemy.GetComponent<BasicEnemy>();
            newEnemy.Distracted = false; newEnemy.GoAwake = false;
        }
    }
}
