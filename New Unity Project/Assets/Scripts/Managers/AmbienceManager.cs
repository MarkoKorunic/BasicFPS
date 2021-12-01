using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip forestAmbience;

    private void Awake()
    {
        audioSource.playOnAwake = true;
        audioSource.clip = forestAmbience;
        audioSource.Play();
    }
}
