using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDoing : MonoBehaviour
{
    [SerializeField] private int interactionsToDo;

    [SerializeField] private GameObject nextScript;
    [SerializeField] private LeftTrigger interactionsController;

    private void Update()
    {
        if (interactionsController.InteractionsDone >= interactionsToDo)
        {
            nextScript.SetActive(true);
            enabled = false;
        }
    }
}
