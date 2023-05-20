using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string infoText;

    private void Start()
    {
        text.text = infoText;
    }
}
