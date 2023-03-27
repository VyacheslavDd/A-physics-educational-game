using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLinesToDialog : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private List<string> sentences;

    private void Start()
    {
        dialog.AddSentences(sentences);
    }
}
