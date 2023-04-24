using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoldTestWithInputAnswer : MonoBehaviour
{
    private Dictionary<string, string> questions;
    private List<string> keys;

    [SerializeField] private TMP_InputField field;
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private ClassForSharing shareClass;
    [SerializeField] private TypeCoroutine typing;

    public float AwaitTime;

    private (string question, string answer) currentQuestion;


    private IEnumerator ShowIfCorrectAnswer()
    {
        var standardColor = field.textComponent.color;
        var myAnswer = field.textComponent.text.Trim()[..(field.textComponent.text.Length - 1)].ToLower();
        var actualAnswer = currentQuestion.answer;
        if (string.Equals(myAnswer, actualAnswer, StringComparison.Ordinal)) 
            field.textComponent.color = new Color32(0, 255, 21, 255);
        else field.textComponent.color = new Color32(255, 41, 0, 255);
        field.interactable = false;
        yield return new WaitForSeconds(AwaitTime);
        field.interactable = true;
        field.textComponent.color = standardColor;
    }

    public void TypeQuestion(string question)
    {
        this.question.text = "";
        field.text = "";
        StopAllCoroutines();
        StartCoroutine(typing.TypeText(this.question, question));
    }

    public (string question, string answer) GetNextQuestion()
    {
        if (keys.Count == 0) return (string.Empty, string.Empty);

        var key = keys[keys.Count - 1];
        keys.RemoveAt(keys.Count - 1);
        currentQuestion = (key, questions[key]);
        return currentQuestion;
    }

    public void CheckAnswer()
    {
        StartCoroutine(ShowIfCorrectAnswer());
    }

    public void SetQuestions(Dictionary<string, string> questions)
    {
        this.questions = questions;
        keys = this.questions.Keys.ToList();
        keys.Shuffle();
    }
}
