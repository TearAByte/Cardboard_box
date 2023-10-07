using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
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
            if (enemyStats.targetPlayer != null)
            {
                enemyStats.lastKnownTargetLocation = enemyStats.targetPlayer;
                var q = Quaternion.LookRotation(enemyStats.targetPlayer.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, enemyStats.rotateSpeed * Time.deltaTime);
                if (enemyStats.canSeeCenterTarget)
                {
                    enemyStats.exSus.SetActive(false);
                    enemyStats.exAlert.SetActive(true);
                    return enemyStats.alertState;
                }
            }

        }
        else
        {
            enemyStats.exSus.SetActive(false);
            enemyStats.exAlert.SetActive(false);
            if(enemyStats.lastKnownTargetLocation != null)
            {
                return enemyStats.investigateState;
            }
        }
        return this;
    }

}
