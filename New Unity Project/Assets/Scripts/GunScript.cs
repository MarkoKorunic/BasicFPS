using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] public Camera FPSCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem bulletHitEffect;
    [SerializeField] AudioSource audioSource;
    [SerializeField] public AudioClip gunShotAudio;
    [SerializeField] public Ammunition ammoSlot;
    [SerializeField] UIAmmo uIAmmo;

    public float damage = 10f;
    public float range = 100f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Reload"))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() != 0)
        {
            audioSource.PlayOneShot(gunShotAudio);
            PlayMuzzleFlash();
            ProccesRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }

        else
            Debug.Log("Ammo Depleted!!!");
    }

    void Reload()
    {
        StartCoroutine(uIAmmo.ReloadTimer());
        ammoSlot.ReloadGun();
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
                enemyModel.enemy.TakeDamage(damage);
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
