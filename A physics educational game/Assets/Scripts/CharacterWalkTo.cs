using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkTo : MonoBehaviour
{
    [SerializeField] private bool disableTriggerWhenWalking = true;

    [SerializeField] private TriggerDialog dialog;
    [SerializeField] private NPCBehaviour behaviour;

    [SerializeField] private List<Transform> pointsToGo;

    private void Start()
    {
        if (disableTriggerWhenWalking)
            dialog.gameObject.SetActive(false);
        behaviour.UpdatePointsToGo(pointsToGo);
    }
}
