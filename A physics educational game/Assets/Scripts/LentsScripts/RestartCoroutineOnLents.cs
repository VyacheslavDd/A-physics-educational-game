using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCoroutineOnLents : MonoBehaviour
{
    [SerializeField] private OnMagnetEntered detector;

    private void Start()
    {
        detector.ForcePush();
    }
}
