using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemySO enemySO;
    [SerializeField] public EnemyModel enemyModel;
    
    public float health;

    public delegate void OnHealthChange();
    public static event OnHealthChange HealthDrop;

    private void Start()
    {
        enemyModel = new EnemyModel();
        health = enemySO.health;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        
       
        if (health <= 0f)
        {
            enemyModel.EnemyDeath();
            Debug.Log("Enemy died!!");
        }
        if(health > 0f)
        {
            StartCoroutine(enemyModel.ChangeTargetColorOnHit());
        }
    }

    

   
    
    
}
