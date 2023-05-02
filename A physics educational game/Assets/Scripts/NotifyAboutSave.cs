using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyAboutSave : MonoBehaviour
{
    [SerializeField] private GameObject saveNotifyText;
    [SerializeField] private InfoCoroutine infoCoroutine;

    private void Start()
    {
        infoCoroutine.InitiateMessageCoroutine(saveNotifyText, 2.5f);
    }
}
