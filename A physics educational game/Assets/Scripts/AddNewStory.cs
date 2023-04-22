using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewStory : MonoBehaviour
{
    [SerializeField] private TriggerDialog trigger;
    [SerializeField] private TextAsset story;

    [SerializeField] private bool keepSameStory;

    private void Start()
    {
        trigger.UpdateStory(story, keepSameStory);
    }
}
