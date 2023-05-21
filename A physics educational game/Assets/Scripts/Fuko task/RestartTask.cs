using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTask : MonoBehaviour
{
    [SerializeField] private FukoTaskManager fukoTaskManager;

    private void Start()
    {
        fukoTaskManager.FormStateSequence();
    }
}
