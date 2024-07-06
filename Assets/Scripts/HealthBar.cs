using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] float initialHealth = 5;

    private void Start()
    {
        //slider = GetComponent<Slider>();

        if (slider != null)
        {
            SetHealth(initialHealth);
        }
        else
        {
            Debug.LogError("Slider component not found on " + gameObject.name);
        }
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        if (slider != null)
        {
            slider.maxValue = maxHealth;
        }
    }

    public void ChangeActualHealth(float healthAmount)
    {
        if (slider != null)
        {
            slider.value = healthAmount;
        }
    }

    public void SetHealth(float healthAmount)
    {
        ChangeMaxHealth(healthAmount);
        ChangeActualHealth(healthAmount);
    }
}
