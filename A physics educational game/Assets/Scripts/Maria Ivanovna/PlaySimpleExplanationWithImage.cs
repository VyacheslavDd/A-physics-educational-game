using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaySimpleExplanationWithImage : MonoBehaviour
{
    [SerializeField] private GameObject explanationCanvas;

    [SerializeField] TextAsset text;
    [SerializeField] private TypeCoroutine typeCoroutine;
    [SerializeField] private GameObject nextScript;

    [SerializeField] private TextMeshProUGUI infoText;

    private Story story;

    private void Start()
    {
        explanationCanvas.SetActive(true);
        infoText.text = "";
        story = new Story(text.text);
        StartCoroutine(typeCoroutine.TypeText(infoText, story.Continue()));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (story.canContinue)
            {
                StopAllCoroutines();
                infoText.text = "";
                StartCoroutine(typeCoroutine.TypeText(infoText, story.Continue()));
            }
            else
            {
                nextScript.SetActive(true);
                enabled = false;
            }
        }
    }
}
