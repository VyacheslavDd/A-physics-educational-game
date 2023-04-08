using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonListDialog : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private TextAsset requireFinishTask;
    [SerializeField] private TextAsset justRefuseTalking;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public GameObject scriptAfter;
    public Story story;
    public TriggerDialog triggerDialog;

    public bool activatePlayer;
    public bool continueWithPlayer;

    private void Start()
    {
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (var choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && story.currentChoices.Count == 0)
        {
            Continue();
        }
    }

    public void Continue()
    {
        if (!story.canContinue)
        {
            if (activatePlayer)
            {
                playerControl.enabled = true;
                playerControl.RotateToSpeaker();
                triggerDialog.FinishDialogue();
            }
            if (continueWithPlayer) playerControl.enabled = true;
            dialogCanvas.SetActive(false);
            if (continueWithPlayer) triggerDialog.ResetStory();
            else triggerDialog.UpdateStory(scriptAfter == null ? justRefuseTalking : requireFinishTask);
            if (scriptAfter != null)
            {
                scriptAfter.SetActive(true);
                scriptAfter = null;
            }
            Cursor.visible = false;
        }
        else
        {
            triggerDialog.GetNextSentenceWithAnalysis(story.Continue());
            DisplayChoices();
        }
    }

    private void DisplayChoices()
    {
        var currentChoices = story.currentChoices;
        int index = 0;

        foreach (var choice in currentChoices)
        {
            choices[index].SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index);
        Continue();
    }
}
