using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : BasicEnemy
{
    bool playerInSight;

    public bool PlayerInSight { get => playerInSight; set => playerInSight = value; }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        enemyType = TypeOfEnemy.SmallEnemy;
    }

    public void CoverExit()
    {
        agent.SetDestination(new Vector3 (GM.instance.exitSquare.transform.position.x, 0.655f, GM.instance.exitSquare.transform.position.z));
        Debug.Log("You shall not pass");
    }

    public bool LookAround()
    {
        return First;
    }
}
