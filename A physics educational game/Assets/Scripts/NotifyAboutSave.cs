using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyAboutSave : MonoBehaviour
{
    [SerializeField] private GameObject saveNotifyText;
    [SerializeField] private InfoCoroutine infoCoroutine;

    [SerializeField] private bool ShouldSendMessage = true;

    private void Start()
    {
        if (ShouldSendMessage) infoCoroutine.InitiateMessageCoroutine(saveNotifyText, 2.5f);
    }
}
