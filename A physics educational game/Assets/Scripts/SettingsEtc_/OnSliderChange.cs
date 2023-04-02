using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnSliderChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI associatedText;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource camSource;
    [SerializeField] private ClassForSharing shareClass;

    [SerializeField] private string playerPrefsVariable;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(playerPrefsVariable, shareClass.basicPercent);
        associatedText.text = slider.value + "%";
    }

    public void OnHandleMove()
    {
        associatedText.text = slider.value + "%";
        PlayerPrefs.SetFloat(playerPrefsVariable, slider.value);
        if (camSource != null) camSource.volume = shareClass.basicVolume * (slider.value / 100);
    }
}
