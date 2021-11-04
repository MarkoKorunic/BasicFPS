using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    
    [SerializeField]public Camera FPSCamera;
    public float damage = 10f;
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            Debug.Log("You shoot " + hit.transform.name);
            EnemyModel enemyModel = hit.transform.GetComponent<EnemyModel>();

            if (enemyModel != null)
            {
                enemyModel.DamageRecieved(damage);
            }            
        }
    }
}
