using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageAmount)
    {
        hitPoints -= damageAmount;
        if(hitPoints > 0)
        {
            Debug.Log("You recieved " + damageAmount + "damage.");
        }

        if (hitPoints <= 0f)
        {
            Debug.Log("You are dead.");
        }
       
    }

}
