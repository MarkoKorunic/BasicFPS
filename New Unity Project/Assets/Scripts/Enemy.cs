using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemyModel enemyModel;
    [SerializeField] public List<EnemySO> enemies;
    [SerializeField] public EnemyAI enemyAI;

    public float damage = 0f;

    private float health;
    private float size;

    private void OnEnable()
    {
        SetEnemyAttributes();
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
    private void SetEnemyAttributes()
    {
        EnemySO enemySO = GetRandomEnemySO();
        size = (float)enemySO.enemySize;
        SetEnemySize(size);
        health = enemySO.health;
    }

    public EnemySO GetRandomEnemySO()
    {
        System.Random random = new System.Random();
        int index = random.Next(enemies.Count);
        return enemies[index];
    }

}
