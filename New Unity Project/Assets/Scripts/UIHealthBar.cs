using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    public Slider slider;
    public Image healthColor;


    private void Update()
    {
        SetPlayerHealth();
       
    }
    public void SetPlayerHealth()
    {
        slider.value = playerHealth.currentHitPoints;
        HealthBarColorChange();
    }

    public void HealthBarColorChange()
    {
        if (slider.value > 500f)
            healthColor.color = Color.green;
        if (slider.value <= 500f && slider.value > 200)
            healthColor.color = Color.yellow;
        if (slider.value <= 200)
            healthColor.color = Color.red;
    }
}
