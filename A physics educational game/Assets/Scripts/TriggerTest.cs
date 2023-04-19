using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTest : MonoBehaviour
{
    [SerializeField] private HoldTestWithInputAnswer testManager;
    [SerializeField] private Sprite teacherSprite;
    [SerializeField] private GameObject testCanvas;
    [SerializeField] private Image teacherImage;
    [SerializeField] private PlayerControl control;

    [SerializeField] private List<string> lines;

    private Dictionary<string, string> questions;

    private (string question, string answer) currentQuestion;

    private bool shouldWait;

    private void Start()
    {
        questions = new Dictionary<string, string>();
        foreach (var line in lines)
        {
            var data = line.Split(';');
            questions[data[0]] = data[1].Trim();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            Cursor.visible = true;
            teacherImage.sprite = teacherSprite;
            testCanvas.SetActive(true);
            control.enabled = false;
            control.ResetAnimations();
            testManager.SetQuestions(questions);
            currentQuestion = testManager.GetNextQuestion();
            StartCoroutine(testManager.TypeQuestion(currentQuestion.question));

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !shouldWait)
        {
            testManager.CheckAnswer();
            StartCoroutine(SeeWhetherRightAnswer());
        }
    }

    private IEnumerator SeeWhetherRightAnswer()
    {
        shouldWait = true;
        yield return new WaitForSeconds(testManager.AwaitTime);
        shouldWait = false;
        currentQuestion = testManager.GetNextQuestion();

        if (currentQuestion.question == string.Empty)
        {
            testManager.StopAllCoroutines();
            testCanvas.SetActive(false);
            control.enabled = true;
            Cursor.visible = false;
        }
        else
            StartCoroutine(testManager.TypeQuestion(currentQuestion.question));
    }
}
