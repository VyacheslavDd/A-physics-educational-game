using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackIfPlayerInteractedWithFuko : MonoBehaviour
{
    [SerializeField] private Animator fuko;
    [SerializeField] private string triggerAnimation;

    [SerializeField] private GameObject nextScript;
    [SerializeField] private GameObject ReminderText;

    private bool hasInteracted;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            hasInteracted = true;
            fuko.SetTrigger(triggerAnimation);
            nextScript.SetActive(true);
            ReminderText.SetActive(false);
        }
    }
}
