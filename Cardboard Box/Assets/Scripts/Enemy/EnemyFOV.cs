using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask playerTarget;
    public LayerMask obstacles;

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);    
    }
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    void FindVisibleTargets()
    {
        //Checks players/targets within view radius
        Collider[] targetsWithinViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerTarget);
        for (int i=0; i< targetsWithinViewRadius.Length; i++)
        {
            Transform target = targetsWithinViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            //checks players/targets within view angle
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                //checks if theres obstacles obscuring players/obstacles
                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacles))
                {
                    Debug.Log("Enemy Contact!");
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal){
            angleInDegrees += transform.eulerAngles.y;
        }
        //converts trigo degrees to unity or vice verse idk which one lmaooooo
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


}
