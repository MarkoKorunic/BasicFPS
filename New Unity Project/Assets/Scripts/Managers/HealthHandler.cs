using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HealthHandler 
{
    public Action<float> OnHealthChange;
    public float health { get; private set; }

    public HealthHandler(Action<float> onHealthChange, float startHealth)
    {
        OnHealthChange = onHealthChange;
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            Debug.Log("You recieved " + damage + "damage.");
        }
        this.OnHealthChange(health);
    }
}
