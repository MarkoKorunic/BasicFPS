using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemySO enemySO;
    private Color hitColor = Color.red;
    private Color baseColor = Color.white;

    float health;

    Rigidbody rigidbody;
    Renderer renderer;
    Animator animator;

    private float hitColorChangeTimer = 0.5f;
    private float enemyDeathFallTimer = 1.5f;

    public delegate void OnHealthChange();
    public static event OnHealthChange HealthDrop;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        health = enemySO.health;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        
       
        if (health <= 0f)
        {
            animator.enabled = false;
            EnemyDeath();
            Debug.Log("Enemy died!!");
            

        }
        if(health > 0f)
        {
            StartCoroutine(ChangeTargetColorOnHit());
        }
    }

    private void EnemyDeath()
    {
        rigidbody.useGravity = true;
    }

    public IEnumerator ChangeTargetColorOnHit()
    {
        renderer.material.color = hitColor;
        yield return new WaitForSeconds(hitColorChangeTimer);
        renderer.material.color = baseColor;
    }
     
    
    
}
