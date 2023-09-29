using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobIdleState : State
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
            return enemyStats.susState;
        }
        return this;
    }

}
