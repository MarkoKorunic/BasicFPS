using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    Rigidbody rigidbody;
    Renderer renderer;

    private Color hitColor = Color.red;
    private Color baseColor = Color.white;

    private float hitColorChangeTimer = 0.5f;
    private float enemyDeathFallTimer = 1.5f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }

    public void EnemyDeath()
    {
        rigidbody.useGravity = true;
    }

    public IEnumerator ChangeTargetColorOnHit()
    {
        renderer.material.color = hitColor;
        yield return new WaitForSeconds(hitColorChangeTimer);
        renderer.material.color = baseColor;
    }

}
