using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] Enemy enemy;

    public float damage = 5f;
    public float nearbyEnemyDetectionRadius = 5f;
    public float wanderRadius = 5f;
    public float wanderTimer = 10f;
    public bool isProvoked = false;
    public Transform target;
    public Enemy[] nearbyEnemies;
    public NavMeshAgent navMeshAgent;

    private float distanceToTarget = Mathf.Infinity;
    private GameObject targetObject;
    private GameObject nearbyEnemy;

    private void Start()
    {
        enemy.enemyModel.animator.SetBool("Attack", false);
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetObject = GameObject.FindGameObjectWithTag("Player");
        target = targetObject.transform;
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked == true)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

        else
            RandomWalk();
    }

    private void RandomWalk()
    {
        enemy.enemyModel.animator.SetTrigger("Walk");
        float timer = wanderTimer;
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            navMeshAgent.SetDestination(newPos);
        }
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
        enemy.enemyModel.animator.SetTrigger("Run");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        if (target == null) return;
        enemy.enemyModel.animator.SetBool("Attack", true);
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Enemy attacks player.");
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void FindAndSaveNearbyEnemies()
    {

    }
}
