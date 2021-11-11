using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField]PlayerHealth playerHealth;
    public Slider slider;



    private void Update()
    {
        SetPlayerHealth();
    }
    public void SetPlayerHealth()
    {
        slider.value = playerHealth.currentHitPoints;
    }

}
