using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetNewTask : MonoBehaviour
{
    [SerializeField] private GameObject taskPrefab;
    [SerializeField] private string taskText;
    [SerializeField] private Transform panel;
    [SerializeField] private TextMeshProUGUI taskUpdatedMention;
    [SerializeField] private InfoCoroutine infoCoroutine;
    [SerializeField] private DeleteTaskAfterCompleting trackTask;

    [SerializeField] private bool ShouldSendMessage = true;

    private void Start()
    {
        var task = Instantiate(taskPrefab, panel);
        task.GetComponent<TextMeshProUGUI>().text = taskText;
        if (trackTask != null)
            trackTask.TaskToDelete = task;
        StopAllCoroutines();
        if (ShouldSendMessage) infoCoroutine.InitiateMessageCoroutine(taskUpdatedMention.gameObject, 3);
    }
}
