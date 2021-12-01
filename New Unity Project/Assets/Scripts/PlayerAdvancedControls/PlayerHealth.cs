using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerDeathHandler deathHandler;

    
    public float maxHitPoints = 1000f;
    public HealthHandler healthHandler;

    private void Start()
    {
        healthHandler = new HealthHandler(this.OnHealthChange, this.maxHitPoints);
    }

    public void TakeDamage(float damageAmount)
    {
        healthHandler.TakeDamage(damageAmount);
    }

    private void OnHealthChange(float health)
    {
        if(health <= 0)
        deathHandler.HandleDeath();
    }
}
