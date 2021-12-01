using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] Player player;
    public Slider slider;
    public Image healthColor;

    void Update()
    {
        SetPlayerHealth();
    }
    public void SetPlayerHealth()
    {
        slider.value = player.healthHandler.health;
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
