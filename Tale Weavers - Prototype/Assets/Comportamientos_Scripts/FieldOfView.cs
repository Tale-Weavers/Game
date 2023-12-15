using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public LayerMask playerMask;
    public LayerMask wallMask;
    public LayerMask woolballMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new();    
    [HideInInspector]
    public List<Transform> visibleDistractions = new();
    AEnemy initialEnemy;

    private void Start()
    {
        StartCoroutine(FindTargetsDelay());
        initialEnemy = GetComponent<AEnemy>();
    }
    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void FindVisibleTargets()
    {
        BasicEnemy enemy = GetComponent<BasicEnemy>();
        if (enemy.Distracted == true) return;
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
        Collider[] distractionsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, woolballMask);

        foreach(Collider target in targetsInViewRadius)
        {
            Transform targetTransform = target.transform;
            Vector3 dirToTarget = (targetTransform.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle/2)
            {
                float distToTarget = Vector3.Distance(transform.position, targetTransform.position);
                if(!Physics.Raycast(transform.position, dirToTarget, distToTarget, wallMask))
                {
                    if (!targetTransform.GetComponent<PlayerBehaviour>().Hidden)
                    {
                        enemy.LostVision = false;
                        visibleTargets.Add(targetTransform);
                        enemy.PlayerSeen = true;
                        enemy.PlayerPos = target.gameObject;
                        GM.instance.NotifyEnemies(true);
                        enemy.First = true;
                    }
                }
                else
                {
                    if(enemy.PlayerPos != null && enemy.PlayerPos.GetComponent<PlayerBehaviour>().Hidden)
                    {
                        enemy.LostVision = true;
                        GM.instance.CheckLostVision();
                    }
                }
            }
        }
        if (!enemy.LostVision&& targetsInViewRadius.Length == 0 && GM.instance.player.Hidden)
        {
            enemy.LostVision = true;
            GM.instance.CheckLostVision();
        }

        foreach (Collider target in distractionsInViewRadius)
        {
            Transform targetTransform = target.transform;
            Vector3 dirToTarget = (targetTransform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, targetTransform.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, wallMask))
                {
                    targetTransform.GetComponent<ContinuousWoolBall>().AddEnemy(enemy);
                    if (!targetTransform.GetComponent<ContinuousWoolBall>().beingPlayed)
                    {
                        visibleDistractions.Add(targetTransform);
                        targetTransform.GetComponent<ContinuousWoolBall>().beingPlayed = true;
                        enemy.Distracted = true;
                        enemy.Distraction = target.GetComponent<ContinuousWoolBall>();
                    }
                    else
                    {
                        enemy.Distraction = target.GetComponent<ContinuousWoolBall>();
                        enemy.GoAwake = true;
                        Debug.Log("mi pana esta jugando re loco");
                    }
                }
            }
        }
    }

    void FindPlayer()
    {
        CleanerEnemy enemy = GetComponent<CleanerEnemy>();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
        

        foreach (Collider target in targetsInViewRadius)
        {
            Transform targetTransform = target.transform;
            Vector3 dirToTarget = (targetTransform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, targetTransform.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, wallMask))
                {
                    if (!targetTransform.GetComponent<PlayerBehaviour>().Hidden)
                    {
                        visibleTargets.Add(targetTransform);
                        enemy.PlayerPos = target.gameObject;
                        enemy.PlayerInSight = true;
                    }
                    else
                    {
                        enemy.PlayerInSight = false;
                    }
                } 
            }
            
        }
        if(targetsInViewRadius.Length == 0)
        {
            enemy.PlayerInSight = false;
        }
    }

    void LookForPlayer()
    {
        DetectiveEnemy enemy = GetComponent<DetectiveEnemy>();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerMask);


        foreach (Collider target in targetsInViewRadius)
        {
            Transform targetTransform = target.transform;
            Vector3 dirToTarget = (targetTransform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, targetTransform.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, wallMask))
                {
                    if (!targetTransform.GetComponent<PlayerBehaviour>().Hidden)
                    {
                        visibleTargets.Add(targetTransform);
                        enemy.PlayerPos = target.gameObject;
                        enemy.currentState = DetectiveEnemy.State.Fleeing;
                        GM.instance.NotifyEnemies(true);
                    }
                    else
                    {
                        
                        GM.instance.CheckLostVision();
                    }
                }
            }

        }
        if (targetsInViewRadius.Length == 0)
        {
            if(enemy.currentState == DetectiveEnemy.State.Fleeing)
            {
                enemy.currentState = DetectiveEnemy.State.Returning;
            }
        }
    }

    IEnumerator FindTargetsDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            visibleTargets.Clear();

            switch (initialEnemy.enemyType)
            {
                case AEnemy.TypeOfEnemy.BasicEnemy:
                    FindVisibleTargets();
                    break;
                case AEnemy.TypeOfEnemy.CleanerEnemy:
                    FindPlayer();
                    break;
                case AEnemy.TypeOfEnemy.SmallEnemy:
                    FindVisibleTargets();
                    break;
                case AEnemy.TypeOfEnemy.DetectiveEnemy:
                    LookForPlayer();
                    break;
            }
            
        }
    }


}
