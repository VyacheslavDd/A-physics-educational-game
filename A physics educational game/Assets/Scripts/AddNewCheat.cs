using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddNewCheat : MonoBehaviour
{
    [SerializeField] private List<GameObject> partOfCheat;
    [SerializeField] private InfoCoroutine info;

    [SerializeField] private GameObject infoCheatText;

    [SerializeField] private bool ShouldSendMessage = true;

    private void Start()
    {
        foreach (var part in partOfCheat)
            part.SetActive(true);
        if (ShouldSendMessage) info.InitiateMessageCoroutine(infoCheatText, 2f);
    }
}
