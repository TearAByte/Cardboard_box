using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSusState : State
{

    EnemyMobStatus enemyStats;
    private void Awake()
    {
        enemyStats = gameObject.GetComponent<EnemyMobStatus>();
    }
    public override State RunCurrentState()
    {
        if (enemyStats.canSeeTarget)
        {
            enemyStats.exSus.SetActive(true);
            var q = Quaternion.LookRotation(enemyStats.targetPlayer.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, enemyStats.rotateSpeed * Time.deltaTime);
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            if (Physics.Raycast(transform.position, Vector3.forward, enemyStats.enemyFOV.viewRadius, enemyStats.enemyFOV.playerTarget))
            {
                enemyStats.exSus.SetActive(false);
                enemyStats.exAlert.SetActive(true);
            }
            else
            {
                enemyStats.exSus.SetActive(true);
                enemyStats.exAlert.SetActive(false);
            }

        }
        else
        {
            enemyStats.exSus.SetActive(false);
            enemyStats.exAlert.SetActive(false);
        }
        return this;
    }

}
