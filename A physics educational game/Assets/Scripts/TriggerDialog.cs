using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialog : MonoBehaviour
{
    [SerializeField] private TextAsset jsonDATA;
    private Story story;
    private static string mainCharacterName = "Δενθρ";
    [SerializeField] private PlayerControl control;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject insertionCanvas;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI sentenceText;
    [SerializeField] private Image characterImage;
    [SerializeField] private GameObject scriptAfter;
    [SerializeField] private Sprite characterSprite;
    [SerializeField] private string characterName;
    [SerializeField] private Sprite myCharacterSprite;
    [SerializeField] private ButtonListDialog button;
    [SerializeField] private InfoCoroutine infoCoroutine;
    [SerializeField] private MaxTasksQuantity maxTasks;
    [SerializeField] private Transform panel;
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject talkWarning;
    [SerializeField] private ClassForSharing shareClass;

    [SerializeField] private bool startAutomatically;
    [SerializeField] private bool isScripted;
    [SerializeField] private bool hasInfo;
    [SerializeField] private bool shouldOpponentWait;
    [SerializeField] private bool keepSameStory;

    private bool isIn;

    private void Start()
    {
        story = new Story(jsonDATA.text);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null && !startAutomatically)
        {
            transform.parent.GetComponent<NPCBehaviour>().GetReadyForDialogue();
            talkWarning.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            isIn = false;
            if (!startAutomatically)
            {
                talkWarning.SetActive(false);
                transform.parent.GetComponent<NPCBehaviour>().FinishDialogue();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            if ((Input.GetKey(KeyCode.E) || startAutomatically) && 
                !dialogCanvas.activeSelf && !isIn && !insertionCanvas.activeSelf)
            {
                if (panel.childCount <= maxTasks.GetAmountOfMaxTasks() || startAutomatically)
                {
                    isIn = true;
                    if (!startAutomatically)
                    {
                        transform.parent.GetComponent<NPCBehaviour>().GetReadyForDialogue();
                        control.RotateToSpeaker(transform.parent);
                        control.enabled = false;
                        control.ResetAnimations();
                    }
                    if (hasInfo) { control.enabled = false; control.ResetAnimations(); }
                    Cursor.visible = true;
                    dialogCanvas.SetActive(true);
                    UpdateSpeakerInfo(characterName, characterSprite);
                    GetNextSentenceWithAnalysis(story.Continue());
                    button.story = story;
                    button.scriptAfter = scriptAfter;
                    button.triggerDialog = this;
                    button.activatePlayer = !startAutomatically;
                    button.continueWithPlayer = hasInfo;
                    button.shouldWaitBeforeCompleting = shouldOpponentWait;
                    button.keepSameStory = keepSameStory;
                    button.isScripted = isScripted;
                }
                else
                {
                    warning.GetComponent<TextMeshProUGUI>().text = $"You already have {maxTasks.GetStringInterpretation()} task(s)!";
                    StopAllCoroutines();
                    StartCoroutine(infoCoroutine.DoInfoCoroutine(warning, 3));
                }
            }
        }
    }

    public void UpdateScriptAfter(GameObject script)
    {
        scriptAfter = script;
    }

    public void UpdateStory(TextAsset story, bool keepSame=false)
    {
        jsonDATA = story;
        this.story = new Story(story.text);
        keepSameStory = keepSame;
    }

    public void ResetStory()
    {
        story = new Story(jsonDATA.text);
    }

    public void FinishDialogue()
    {
        isIn = false;
        if (!isScripted) transform.parent.GetComponent<NPCBehaviour>().FinishDialogue();
    }

    private void UpdateSpeakerInfo(string name, Sprite character)
    {
        nameText.text = name;
        characterImage.sprite = character;
    }

    public void GetNextSentenceWithAnalysis(string sentence)
    {
        sentenceText.text = "";
        StopAllCoroutines();
        var author = sentence[0];
        var meaning = sentence.Substring(2);
        if (author == 'c') UpdateSpeakerInfo(mainCharacterName, myCharacterSprite);
        else UpdateSpeakerInfo(characterName, characterSprite);
        StartCoroutine(writeSentenceLetterByLetter(sentenceText, meaning));
    }

    private IEnumerator writeSentenceLetterByLetter(TextMeshProUGUI text, string sentence)
    {
        var time = shareClass.basicTextSpeed * (1 - PlayerPrefs.GetFloat("textSpeed", shareClass.basicPercent) / 100);
        foreach (var letter in sentence)
        {
            text.text += letter;
            yield return new WaitForSeconds(time);
        }
    }
}
