using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider; 
    [SerializeField] private Camera camera;

    public void UpdatePlayerHealthbar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    void Update()
    {
        transform.rotation = camera.transform.rotation; //health bar UI stays fixed on the screen
    }
}
