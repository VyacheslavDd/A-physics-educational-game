using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKnownDinnerInfoQuantity : MonoBehaviour
{
    [SerializeField] private TaskWithTimer timerTask;

    private void Start()
    {
        timerTask.AddManAsked();
    }
}
