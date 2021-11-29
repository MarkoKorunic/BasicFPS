using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    [SerializeField] Text ammoCounter;
    [SerializeField] GunScript gunScript;
    [SerializeField] Image reloadImageBar;
    [SerializeField] Text reloadText;

    private float fullReloadTime = 3f;
    private float reloadTimeLeft;

    private void Start()
    {
        reloadImageBar.fillAmount = 0;
    }
    void Update()
    {
        ammoCounter.text = Convert.ToString(gunScript.ammoSlot.GetCurrentAmmo());
    }

    public IEnumerator ReloadTimer()
    {
        gunScript.isReloading = true;
        reloadTimeLeft = fullReloadTime;
        if (reloadTimeLeft > 0)
        {
            reloadText.text = "Reloading...";
            reloadTimeLeft -= Time.deltaTime;
            reloadImageBar.fillAmount = reloadTimeLeft / fullReloadTime;
        }
        yield return new WaitForSeconds(3f);
        reloadText.text = "";
        reloadImageBar.fillAmount = 0;
        Debug.Log("Gun Reloaded");
        gunScript.ammoSlot.ReloadGun();
        gunScript.isReloading = false;
    }

}
