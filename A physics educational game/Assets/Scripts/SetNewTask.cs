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

    private void Start()
    {
        var task = Instantiate(taskPrefab, panel);
        task.GetComponent<TextMeshProUGUI>().text = taskText;
        if (trackTask != null)
            trackTask.TaskToDelete = task;
        StopAllCoroutines();
        StartCoroutine(infoCoroutine.DoInfoCoroutine(taskUpdatedMention.gameObject, 3));
    }
}
