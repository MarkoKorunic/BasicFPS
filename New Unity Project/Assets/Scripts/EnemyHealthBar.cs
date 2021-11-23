using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float updateSpeed = 0.5f;
    [SerializeField] Enemy enemy;

    private void Start()
    {
        enemy.healthHandler.OnHealthChange += HandleHealthChange;
    }

    private void HandleHealthChange(float healthPercent)
    {
        StartCoroutine(HealthPercentChange(healthPercent));
    }

    private IEnumerator HealthPercentChange(float percent)
    {
        float preChangePercent = fillImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeed)
        {
            elapsed += Time.deltaTime;
            fillImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsed / updateSpeed);
            yield return null;
        }

        fillImage.fillAmount = percent;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }




}
