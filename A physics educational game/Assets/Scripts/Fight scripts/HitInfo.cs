using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitInfo : MonoBehaviour
{
    private TextMeshProUGUI infoText;

    private void Start()
    {
        infoText = GetComponent<TextMeshProUGUI>();
    }

    private IEnumerator ShowInfo(string text, Color color)
    {
        infoText.text = text;
        infoText.color = color;
        infoText.enabled = true;
        yield return new WaitForSeconds(1.5f);
        infoText.enabled = false;
    }

    public void ShowHitInfo(string text, Color color)
    {
        StopAllCoroutines();
        StartCoroutine(ShowInfo(text, color));
    }
}
