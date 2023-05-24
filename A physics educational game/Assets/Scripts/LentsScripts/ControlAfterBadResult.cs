using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAfterBadResult : MonoBehaviour
{
    [SerializeField] private PlayerControl control;
    [SerializeField] private GameObject badSequence;

    private void Update()
    {
        if (control.enabled && badSequence.activeSelf)
        {
            badSequence.SetActive(false);
        }
    }
}
