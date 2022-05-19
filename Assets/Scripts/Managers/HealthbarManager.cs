using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthbarManager : MonoBehaviour
{

    public Slider healthbarSlider;

    private void Start() {
        healthbarSlider = GetComponent<Slider>();
    }


    public void SetMaxHealth(int maxHealth) {
        healthbarSlider.maxValue = maxHealth;
        healthbarSlider.value = maxHealth;
    }


    public void SetHealth(int healthAmount) {
        healthbarSlider.value = healthAmount;   
    }

}
