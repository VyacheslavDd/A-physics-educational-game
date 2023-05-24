using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCheat : MonoBehaviour
{
    [SerializeField] private PlayerControl control;

    [SerializeField] private GameObject testCanvas;
    [SerializeField] private GameObject taskCanvas;
    [SerializeField] private GameObject cheatSheet;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && (control.enabled || testCanvas.activeSelf) && !taskCanvas.activeSelf)
        {
            cheatSheet.SetActive(true);
            Cursor.visible = true;
        }

        else
        {
            cheatSheet.SetActive(false);
            Cursor.visible = false;
        }
    }
}
