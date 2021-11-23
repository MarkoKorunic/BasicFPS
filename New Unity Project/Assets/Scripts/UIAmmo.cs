using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    [SerializeField] Text ammoCounter;
    [SerializeField] GunScript gunScript;
    void Update()
    {
        ammoCounter.text = Convert.ToString(gunScript.ammoSlot.GetCurrentAmmo());

    }

}
