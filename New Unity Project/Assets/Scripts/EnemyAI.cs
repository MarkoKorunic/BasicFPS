using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] EnemyModel enemyModel;
    public float damage = 5f;
    public Transform target;

    private GameObject targetObject;
    private float walkingSpeed = 0.3f;
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

        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

        else
            WalkInCircle();
    }

    private void WalkInCircle()
    {
        enemyModel.animator.SetTrigger("Walk");
        transform.position += transform.forward * (navMeshAgent.speed * walkingSpeed) * Time.deltaTime;
        transform.Rotate(0f, -0.3f, 0f);
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (navMeshAgent.remainingDistance <= 2.6f)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        enemyModel.animator.SetBool("Attack", false);
        enemyModel.animator.SetTrigger("Run");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        if (target == null) return;
        enemyModel.animator.SetBool("Attack", true);
        target.GetComponent<Player>().TakeDamage(damage);
        Debug.Log("Enemy attacks player.");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
