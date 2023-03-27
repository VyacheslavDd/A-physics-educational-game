using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeedEffect : MonoBehaviour
{
    private PlayerControl control;
    [SerializeField] private Text speedText;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private float addSpeed;

    private void Awake()
    {
        control = GetComponent<PlayerControl>();
    }

    private void ChangeEffectStatus(bool status, float addSpeed)
    {
        speedText.gameObject.SetActive(status);
        speedSlider.gameObject.SetActive(status);
        control.AddSpeedEffect(addSpeed);
    }

    private void RefillEffect()
    {
        ChangeEffectStatus(true, addSpeed);
        speedSlider.value = speedSlider.maxValue;
    }

    private void Update()
    {
        speedSlider.value -= Time.deltaTime;
        if (speedSlider.value <= speedSlider.minValue)
        {
            ChangeEffectStatus(false, -addSpeed);
            enabled = false;
        }
    }
}
