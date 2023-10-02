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

    [Header("Booleans")]
    public bool canSeeTarget = false;
    public bool canSeeCenterTarget = false;

    [Header("GameObjects")]
    public GameObject exSus;
    public GameObject exAlert;
    public Transform targetPlayer = null;
    
    [Header("Stats")]
    public float rotateSpeed = 1f;
    

    private void Awake()
    {
        idleState = gameObject.GetComponent<MobIdleState>();
        susState = gameObject.GetComponent<MobSusState>();
        enemyFOV = gameObject.GetComponent<EnemyFOV>();
        exAlert.SetActive(false);
        exSus.SetActive(false);
    }
    private void Update()
    {
        canSeeCenterTarget = enemyFOV.canSeeCenterTarget;
        canSeeTarget = enemyFOV.canSeeTarget;
        targetPlayer = enemyFOV.targetPlayer; //retrieves target transform
    }
}
