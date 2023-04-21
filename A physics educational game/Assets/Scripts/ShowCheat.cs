using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCheat : MonoBehaviour
{
    [SerializeField] private PlayerControl control;

    [SerializeField] private GameObject testCanvas;
    [SerializeField] private GameObject cheatSheet;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && (control.enabled || testCanvas.activeSelf))
            cheatSheet.SetActive(true);

        else cheatSheet.SetActive(false);
    }
}
