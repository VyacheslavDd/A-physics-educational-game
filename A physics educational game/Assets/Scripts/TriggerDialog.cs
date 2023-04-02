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

    private void Start()
    {
        story = new Story(jsonDATA.text);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            transform.parent.GetComponent<NPCBehaviour>().GetReadyForDialogue();
            talkWarning.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            talkWarning.SetActive(false);
            transform.parent.GetComponent<NPCBehaviour>().FinishDialogue();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            if (Input.GetKey(KeyCode.E) && !dialogCanvas.activeSelf)
            {
                if (panel.childCount <= maxTasks.GetAmountOfMaxTasks())
                {
                    transform.parent.GetComponent<NPCBehaviour>().GetReadyForDialogue();
                    Cursor.visible = true;
                    dialogCanvas.SetActive(true);
                    UpdateSpeakerInfo(characterName, characterSprite);
                    GetNextSentenceWithAnalysis(story.Continue());
                    control.RotateToSpeaker(transform.parent);
                    control.enabled = false;
                    control.ResetAnimations();
                    button.story = story;
                    button.scriptAfter = scriptAfter;
                    button.triggerDialog = this;
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

    public void UpdateStory(TextAsset story)
    {
        this.story = new Story(story.text);
    }

    public void FinishDialogue()
    {
        transform.parent.GetComponent<NPCBehaviour>().FinishDialogue();
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
