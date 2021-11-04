using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemySO enemySO;
    [SerializeField] public EnemyModel enemyModel;

    private float health;

    private void Start()
    {
        health = enemySO.health;
    }
   
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Enemy died!!");
        }
        if (health > 0f)
        {
            StartCoroutine(enemyModel.ChangeTargetColorOnHit());
            Debug.Log("Enemy taken " + damageAmount + " damage!");
        }
    }
    
}
