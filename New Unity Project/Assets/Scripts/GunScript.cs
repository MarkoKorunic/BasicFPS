using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    
    [SerializeField]public Camera FPSCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem bulletHitEffect;
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
        PlayMuzzleFlash();
        ProccesRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProccesRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            PlayBulletHitImpact(hit);
            Debug.Log("You shoot " + hit.transform.name);
            EnemyModel enemyModel = hit.transform.GetComponent<EnemyModel>();

            if (enemyModel != null)
            {
                enemyModel.DamageRecieved(damage);
            }
            else return;
        }
    }

    private void PlayBulletHitImpact(RaycastHit raycastHit)
    {
        ParticleSystem hitImpact = Instantiate(bulletHitEffect, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
        Destroy(hitImpact, 1);
    }
}
