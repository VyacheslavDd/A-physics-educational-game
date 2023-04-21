using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScriptAfter : MonoBehaviour
{
    [SerializeField] private TriggerDialog dialog;
    [SerializeField] private GameObject scriptAfter;

    private void Start()
    {
        dialog.UpdateScriptAfter(scriptAfter);
    }
}
