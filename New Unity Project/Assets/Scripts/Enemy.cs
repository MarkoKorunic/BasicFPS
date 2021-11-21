using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemyModel enemyModel;
    [SerializeField] public EnemySO[] enemies;
    [SerializeField] public EnemyAI enemyAI;
    [SerializeField] public AudioClip enemyDeathSound;
    [SerializeField] AudioSource source;


    public HealthHandler healthHandler;
    public float initialHealth;

    private float size;

    private void OnEnable()
    {
        SetEnemyAttributes();
        healthHandler = new HealthHandler(this.OnHealthChange, this.initialHealth);
        source = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damageAmount)
    {
        healthHandler.TakeDamage(damageAmount);
    }
    
    void SetEnemySize(float size)
    {
        gameObject.transform.localScale += new Vector3(size,size,size);
    }
   

    public EnemySO GetRandomEnemySO()
    {
        return enemies[UnityEngine.Random.Range(0, enemies.Length - 1)];
    }

    private void OnHealthChange(float health)
    {
        if (health <= 0)
            EnemyDeath();
    }

    private void EnemyDeath()
    {
        enemyModel.animator.SetBool("Death", true);
        source.PlayOneShot(enemyDeathSound);
        Destroy(gameObject, 1f);
        Debug.Log("Enemy died!!");
    }


    private void SetEnemyAttributes()
    {
        EnemySO enemySO = GetRandomEnemySO();
        size = (float)enemySO.enemySize;
        SetEnemySize(size);
        initialHealth = enemySO.health;
    }
}
