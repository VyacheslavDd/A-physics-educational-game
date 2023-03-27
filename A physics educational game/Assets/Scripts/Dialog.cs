using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    private Queue<string> dialogSequence;

    private void Awake()
    {
        dialogSequence = new Queue<string>();
    }

    public bool CanGetNextSentence()
    {
        return dialogSequence.Count > 0;
    }

    public string GetNextSentence()
    {
        return dialogSequence.Dequeue();
    }

    public void AddSentences(List<string> sentences)
    {
        dialogSequence.Clear();
        foreach (var sentence in sentences) dialogSequence.Enqueue(sentence);
    }

    public IEnumerator writeSentenceLetterByLetter(TextMeshProUGUI text, string sentence)
    {
        foreach (var letter in sentence)
        {
            text.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
