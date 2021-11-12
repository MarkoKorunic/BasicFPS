using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] DeathHandler deathHandler;

    public float currentHitPoints;
    public const float maxHitPoints = 1000f;

    private void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHitPoints -= damageAmount;
        if(currentHitPoints > 0)
        {
            Debug.Log("You recieved " + damageAmount + "damage.");
        }

        if (currentHitPoints <= 0f)
        {
            deathHandler.HandleDeath();

        }
       
    }

}
