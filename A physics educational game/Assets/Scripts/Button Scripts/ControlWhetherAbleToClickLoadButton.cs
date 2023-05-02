using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlWhetherAbleToClickLoadButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        if (PlayerPrefs.GetString("Last Save") == string.Empty)
        {
            button.interactable = false;
            text.color = new Color32(135, 135, 135, 255);
        }
    }
}
