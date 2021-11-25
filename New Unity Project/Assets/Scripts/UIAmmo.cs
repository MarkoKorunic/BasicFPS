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
   
    void Update()
    {
        ammoCounter.text = Convert.ToString(gunScript.ammoSlot.GetCurrentAmmo());
    }

    public IEnumerator ReloadTimer()
    {
        reloadImageBar.fillAmount = 0;
        reloadTimeLeft = fullReloadTime;
        reloadText.text = "Reloading...";
        while (reloadTimeLeft > 0)
        {
            reloadTimeLeft -= Time.deltaTime;
            reloadImageBar.fillAmount = reloadTimeLeft / fullReloadTime;
        }
        reloadText.text = "";
        reloadImageBar.fillAmount = 0;
        yield return new WaitForSeconds(fullReloadTime);
        Debug.Log("Gun Reloaded");
    }

}
