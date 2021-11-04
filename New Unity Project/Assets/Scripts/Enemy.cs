using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemySO enemySO;
    [SerializeField] public EnemyModel enemyModel;

    private float health;
    private float size;
    private void Start()
    {
        size = (float)enemySO.enemySize;
        SetEnemySize(size);
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
    
    void SetEnemySize(float size)
    {
        gameObject.transform.localScale += new Vector3(size,size,size);
    }
}
