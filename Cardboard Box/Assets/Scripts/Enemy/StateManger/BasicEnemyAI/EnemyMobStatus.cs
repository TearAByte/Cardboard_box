using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMobStatus : MonoBehaviour
{
    [Header("States")]
    public EnemyFOV enemyFOV;
    public MobIdleState idleState;
    public MobSusState susState;
    public MobAlertState alertState;
    public MobInvestigateState investigateState;
    

    [Header("Booleans")]
    public bool canSeeTarget = false;
    public bool canSeeCenterTarget = false;
    public bool destinationReached = false;

    [Header("GameObjects")]
    public GameObject exSus;
    public GameObject exAlert;
    public Transform targetPlayer = null;
    public Transform lastKnownTargetLocation = null;
    
    [Header("Stats")]
    public float rotateSpeed = 1f;

    [Header("NavMesh Shit")]
    public NavMeshAgent mobAI;

    private void Awake()
    {
        idleState = gameObject.GetComponent<MobIdleState>();
        susState = gameObject.GetComponent<MobSusState>();
        enemyFOV = gameObject.GetComponent<EnemyFOV>();
        alertState = gameObject.GetComponent<MobAlertState>();
        investigateState = gameObject.GetComponent<MobInvestigateState>();
        mobAI = gameObject.GetComponent<NavMeshAgent>();
        exAlert.SetActive(false);
        exSus.SetActive(false);
    }
    private void Update()
    {
        canSeeCenterTarget = enemyFOV.canSeeCenterTarget;
        canSeeTarget = enemyFOV.canSeeTarget;
        targetPlayer = enemyFOV.targetPlayer; //retrieves target transform
    }
    public void NavMeshCheckDestination()
    {
        // Check if we've reached the destination
        if (!mobAI.pathPending)
        {
            if (mobAI.remainingDistance <= mobAI.stoppingDistance)
            {
                if (!mobAI.hasPath || mobAI.velocity.sqrMagnitude == 0f)
                {
                    destinationReached = true; 
                }
            }
        }
    }
}
