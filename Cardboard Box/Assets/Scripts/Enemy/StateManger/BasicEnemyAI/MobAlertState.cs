using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MobAlertState : State
{
    EnemyMobStatus enemyStats;
    private void Awake()
    {
        enemyStats = gameObject.GetComponent<EnemyMobStatus>();
    }
    public override State RunCurrentState()
    {
        enemyStats.exSus.SetActive(false);
        enemyStats.exAlert.SetActive(false);   
        if (enemyStats.canSeeTarget)
        {
            if (enemyStats.targetPlayer != null)
            { 
                enemyStats.lastKnownTargetLocation = enemyStats.targetPlayer;
                enemyStats.mobAI.SetDestination(enemyStats.targetPlayer.position);
            }
        }
        else
        {
            if (enemyStats.lastKnownTargetLocation != null)
                enemyStats.mobAI.SetDestination(enemyStats.lastKnownTargetLocation.position);
            // Check if we've reached the destination
            enemyStats.NavMeshCheckDestination();
            if(enemyStats.destinationReached)
            {
                enemyStats.destinationReached = false;
                return enemyStats.idleState;
            }
        }
        return this;
    }

}