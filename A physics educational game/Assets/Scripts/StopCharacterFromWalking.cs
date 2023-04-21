using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCharacterFromWalking : MonoBehaviour
{
    [SerializeField] private TriggerDialog dialog;
    [SerializeField] private NPCBehaviour behaviour;

    private void Start()
    {
        dialog.gameObject.SetActive(true);
        behaviour.UpdatePointsToGo(new List<Transform>());
    }
}
