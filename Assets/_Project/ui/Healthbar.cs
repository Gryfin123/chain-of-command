using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    [SerializeField] OpponentDataSO source1;
    [SerializeField] PlayerProfileSO source2;
    [SerializeField] Slider healthSlider;

    public void SetMaxHealth(float newMaxHealth)
    {
        healthSlider.maxValue = newMaxHealth;
        healthSlider.value = newMaxHealth;
    }
    public void SetHealth(float newHealth)
    {
        healthSlider.value = newHealth;
    }

    private void Update()
    {
        if (source1 != null)
        {
            healthSlider.maxValue = source1.HpMax;
            healthSlider.value = source1.HpCurrent;
        }
        if (source2 != null)
        {
            healthSlider.maxValue = source2.HpMax;
            healthSlider.value = source2.HpCurrent;
        }
    }
}
