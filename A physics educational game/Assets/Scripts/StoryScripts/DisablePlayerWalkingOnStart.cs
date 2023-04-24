using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerWalkingOnStart : MonoBehaviour
{
    [SerializeField] private PlayerControl control;

    private void Start()
    {
        control.enabled = false;
        control.ResetAnimations();
    }
}
