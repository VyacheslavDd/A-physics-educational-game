using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTask : MonoBehaviour
{
    [SerializeField] private TestTaskManager taskManager;

    private void Start()
    {
        taskManager.FormStateSequence();
    }
}
