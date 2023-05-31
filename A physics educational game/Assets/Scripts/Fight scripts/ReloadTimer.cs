using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReloadTimer : MonoBehaviour
{
    [SerializeField] private ShootingPaper shooting;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = Math.Round(shooting.GetReloadingTime, 2).ToString();
    }
}
