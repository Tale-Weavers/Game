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
    BasicEnemy enemy;

    private void Start()
    {
        StartCoroutine(FindTargetsDelay());
        enemy = GetComponent<BasicEnemy>();
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
                    visibleTargets.Add(targetTransform);
                    enemy.PlayerSeen = true;
                    enemy.PlayerPos = target.gameObject;
                }
            }
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
                        enemy.Distraction = target.gameObject;
                    }
                    else
                    {
                        enemy.Distraction = target.gameObject;
                        enemy.GoAwake = true;
                        Debug.Log("mi pana esta jugando re loco");
                    }
                }
            }
        }
    }

    IEnumerator FindTargetsDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            visibleTargets.Clear();

            FindVisibleTargets();
        }
    }
}
