using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPController : MonoBehaviour
{
    [SerializeField] public Camera FPSCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem bulletHitEffect;
    [SerializeField] AudioSource audioSource;
    [SerializeField] public AudioClip gunShotAudio;
    [SerializeField] public Ammunition ammoSlot;
    [SerializeField] UIAmmo uIAmmo;
    [SerializeField] UIInteractableObject uIInteractable;

    public float gunDamage = 10f;
    public float gunRange = 100f;
    public float interactingRange = 2f;
    public bool isReloading;

    private void Start()
    {
        uIInteractable.gameObject.SetActive(false);
        isReloading = false;
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

        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }

        else
            CheckForInteractables();
    }


    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() != 0 && isReloading == false)
        {
            audioSource.PlayOneShot(gunShotAudio);
            PlayMuzzleFlash();
            GunRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }

        else
            Debug.Log("Ammo Depleted!!!");
    }

    void Reload()
    {
        StartCoroutine(uIAmmo.ReloadTimer());
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    
    void GunRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, gunRange))
        {
            PlayBulletHitImpact(hit);
            Debug.Log("You shoot " + hit.transform.name);
            EnemyModel enemyModel = hit.transform.GetComponent<EnemyModel>();
            if (enemyModel != null)
            {
                enemyModel.enemy.TakeDamage(gunDamage);
            }
            else return;
        }
    }

    private void PlayBulletHitImpact(RaycastHit raycastHit)
    {
        ParticleSystem hitImpact = Instantiate(bulletHitEffect, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
        Destroy(hitImpact.gameObject,0.5f);
    }

    private void Interact()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, interactingRange))
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                interactableObject.DisplayMessage();
            }
            else return;
        }
    }

    private void CheckForInteractables()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, interactingRange))
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                uIInteractable.gameObject.SetActive(true);
            }
            else uIInteractable.gameObject.SetActive(false);
            
        }
    }

}
