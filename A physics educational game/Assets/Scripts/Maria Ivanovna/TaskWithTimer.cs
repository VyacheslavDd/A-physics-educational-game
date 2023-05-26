using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskWithTimer : MonoBehaviour
{
    private double startTimeAmount;

    [SerializeField] private double secondsForTask;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private int peopleToAsk;

    [SerializeField] private GameObject failScript;
    [SerializeField] private GameObject nextSuccessScript;

    private int peopleAsked;

    public void AddManAsked()
    {
        peopleAsked++;
        counterText.text = $"{peopleAsked}/{peopleToAsk}";
    }

    void Start()
    {
        startTimeAmount = secondsForTask;
        timerText.gameObject.SetActive(true);
        counterText.gameObject.SetActive(true);
        counterText.text = $"0/{peopleToAsk}";
        timerText.text = TimeSpan.FromSeconds(secondsForTask).ToString(@"mm\:ss\.ff");
    }

    private void ProcedeWithNextScript(GameObject script)
    {
        counterText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        script.SetActive(true);
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        secondsForTask -= Time.deltaTime;
        timerText.text = TimeSpan.FromSeconds(secondsForTask).ToString(@"mm\:ss\.ff");

        var remainedTimePercent = secondsForTask * 100 / startTimeAmount;
        if (remainedTimePercent >= 50) timerText.color = new Color32(19, 243, 86, 255);
        else if (remainedTimePercent < 50 && remainedTimePercent >= 30) timerText.color = new Color32(236, 252, 10, 255);
        else if (remainedTimePercent < 30 && remainedTimePercent >= 10) timerText.color = new Color32(249, 183, 1, 255);
        else timerText.color = new Color32(255, 68, 0, 255);

        if (peopleAsked >= peopleToAsk)
        {
            ProcedeWithNextScript(nextSuccessScript);
        }

        if (secondsForTask <= 0 && timerText.gameObject.activeSelf)
        {
            ProcedeWithNextScript(failScript);
        }
    }
}
