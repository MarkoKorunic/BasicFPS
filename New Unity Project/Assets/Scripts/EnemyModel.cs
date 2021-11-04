using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    Renderer renderer;
    [SerializeField] Enemy enemy;
    

    private Color hitColor = Color.red;
    private Color baseColor = Color.white;

    private float hitColorChangeTimer = 0.5f;
    private float enemyDeathFallTimer = 1.5f;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }


    public IEnumerator ChangeTargetColorOnHit()
    {
        renderer.material.color = hitColor;
        yield return new WaitForSeconds(hitColorChangeTimer);
        renderer.material.color = baseColor;
    }


    public void DamageRecieved(float damage)
    {
        enemy.TakeDamage(damage);
    }
}
