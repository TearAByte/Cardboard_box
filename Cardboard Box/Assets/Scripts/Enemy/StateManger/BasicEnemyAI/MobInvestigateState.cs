using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MobInvestigateState : State
{

    EnemyMobStatus enemyStats;
    private void Awake()
    {
        enemyStats = gameObject.GetComponent<EnemyMobStatus>();
    }
    public override State RunCurrentState()
    {
        return this;
    }

}
