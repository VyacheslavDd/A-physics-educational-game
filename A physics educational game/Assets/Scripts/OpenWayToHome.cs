using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWayToHome : MonoBehaviour
{
    [SerializeField] private GameObject cannotLeaveTrigger;
    [SerializeField] private GameObject bound;
    [SerializeField] private GameObject endGameTrigger;

    private void Start()
    {
        cannotLeaveTrigger.SetActive(false);
        bound.SetActive(false);
        endGameTrigger.SetActive(true);
    }
}
