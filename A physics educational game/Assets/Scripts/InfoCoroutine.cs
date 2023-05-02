using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCoroutine : MonoBehaviour
{
    private Queue<(GameObject obj, float seconds)> messagesQueue;
    private bool canDoNext = true;

    private void Start()
    {
        messagesQueue = new Queue<(GameObject obj, float seconds)>();
    }

    private IEnumerator DoCoroutine((GameObject text, float seconds) message)
    {
        canDoNext = false;
        message.text.SetActive(true);
        yield return new WaitForSeconds(message.seconds);
        message.text.SetActive(false);
        if (messagesQueue.Count > 0)
            StartCoroutine(DoCoroutine(messagesQueue.Dequeue()));
        else
            canDoNext = true;
    }

    public void InitiateMessageCoroutine(GameObject text, float seconds)
    {
        messagesQueue.Enqueue((text, seconds));
        if (canDoNext) StartCoroutine(DoCoroutine(messagesQueue.Dequeue()));
    }
}
