using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField] public Enemy enemy;
    [SerializeField] Animator animator;
    private void Start()
    {

    }


    public void DamageRecieved(float damage)
    {
        enemy.TakeDamage(damage);
    }
}
