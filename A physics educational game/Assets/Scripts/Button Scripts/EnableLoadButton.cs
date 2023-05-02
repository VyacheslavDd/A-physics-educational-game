using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnableLoadButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        button.interactable = true;
        text.color = new Color32(255, 251, 85, 255);
    }
}
