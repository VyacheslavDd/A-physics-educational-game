using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowResult : MonoBehaviour
{
    [SerializeField] private GameObject allCorrectScript;
    [SerializeField] private GameObject notIdealResultSequence;

    [SerializeField] private TypeCoroutine typeCoroutine;

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private FukoTaskManager fukoTaskManager;

    [SerializeField] private BoxCollider2D playerCollider;

   public IEnumerator DisplayResult(int correctAnswers, int questionsAmount)
    {
        text.text = "";
        text.color = new Color32(255, 255, 255, 255);
        StartCoroutine(typeCoroutine.TypeText(text, $"Правильных ответов: {correctAnswers}/{questionsAmount}"));
        yield return new WaitForSeconds(1.5f);
        GameObject script = null;

        if (correctAnswers == questionsAmount)
        {
            script = allCorrectScript;
            text.color = new Color32(0, 255, 11, 255);
        }
        else
        {
            script = notIdealResultSequence;
            text.color = new Color32(255, 0, 0, 255);
        }

        yield return new WaitForSeconds(1.5f);

        playerCollider.enabled = true;
        script.SetActive(true);
        gameObject.SetActive(false);
    }

    public void UpdateNotIdealScript(GameObject script)
    {
        notIdealResultSequence = script;
    }
}
