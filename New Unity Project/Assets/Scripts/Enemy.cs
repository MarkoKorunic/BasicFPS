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

    public float damage = 0f;
    public float health;

    private float size;

    private void OnEnable()
    {
        SetEnemyAttributes();

        source = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            EnemyDeath();
        }
        if (health > 0f)
        {
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
        return enemies[UnityEngine.Random.Range(0, enemies.Length - 1)];
    }

    void EnemyDeath()
    {
        enemyModel.animator.SetBool("Death", true);
        source.PlayOneShot(enemyDeathSound);
        Destroy(gameObject, 1f);
        Debug.Log("Enemy died!!");
    }

}
