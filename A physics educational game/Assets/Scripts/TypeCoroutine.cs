using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeCoroutine : MonoBehaviour
{
    [SerializeField] private ClassForSharing shareClass;

    public IEnumerator TypeText(TextMeshProUGUI text, string sentence)
    {
        var time = shareClass.basicTextSpeed * (1 - PlayerPrefs.GetFloat("textSpeed", shareClass.basicPercent) / 100);
        foreach (var letter in sentence)
        {
            text.text += letter;
            yield return new WaitForSeconds(time);
        }
    }
}
