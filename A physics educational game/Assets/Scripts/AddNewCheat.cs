using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddNewCheat : MonoBehaviour
{
    [SerializeField] private GameObject partOfCheat;
    [SerializeField] private InfoCoroutine info;

    [SerializeField] private GameObject infoCheatText;

    private void Start()
    {
        partOfCheat.SetActive(true);
        info.InitiateMessageCoroutine(infoCheatText, 2f);
    }
}
