using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask wallMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new();


    private void Start()
    {
        StartCoroutine(FindTargetsDelay());
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
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        foreach(Collider target in targetsInViewRadius)
        {
            Transform targetTransform = target.transform;
            Vector3 dirToTarget = targetTransform.position - transform.position;
            if(Vector3.Angle(dirToTarget, targetTransform.forward) < viewAngle/2)
            {
                float distToTarget = Vector3.Distance(transform.position, targetTransform.position);
                if(!Physics.Raycast(transform.position, dirToTarget, distToTarget, wallMask))
                {
                    visibleTargets.Add(targetTransform);
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
