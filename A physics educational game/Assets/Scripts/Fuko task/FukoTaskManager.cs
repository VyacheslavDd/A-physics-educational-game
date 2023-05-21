using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FukoTaskManager : MonoBehaviour
{
    private List<GameObject> states;
    private int correctAnswers;

    private GameObject resultCanvas;

    private GameObject currentState;
    private int currentIndex;

    private ShowResult showResult;

    private void Start()
    {
        states = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (!child.name.Contains("result"))
            {
                states.Add(child.gameObject);
            }
            else
            {
                resultCanvas = child.gameObject;
            }
        }

        showResult = resultCanvas.GetComponent<ShowResult>();
    }

    private void SetStateActive()
    {
        currentState = states[currentIndex];
        currentState.SetActive(true);

        StartCoroutine(currentState.GetComponent<ShowState>().DisplayState());
    }

    public void FormStateSequence()
    {
        Shuffle.ShuffleArray(new System.Random(), states);
        correctAnswers = 0;
        currentIndex = 0;
        SetStateActive();
    }

    public void ProcedeToNextPage(bool isCorrectAnswer)
    {
        if (isCorrectAnswer) correctAnswers++;
        currentIndex++;
        currentState.SetActive(false);

        if (currentIndex >= states.Count)
        {
            resultCanvas.SetActive(true);
            StartCoroutine(showResult.DisplayResult(correctAnswers, states.Count));
        }
        else
        {
            SetStateActive();
        }
    }
}
