using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    public float damage = 5f;
    public Transform target;

    private GameObject targetObject;
    NavMeshAgent navMeshAgent;
    
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    private void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetObject = GameObject.FindGameObjectWithTag("Player");
        target = targetObject.transform;
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }

        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (navMeshAgent.remainingDistance <= 2)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Enemy attacks player.");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
