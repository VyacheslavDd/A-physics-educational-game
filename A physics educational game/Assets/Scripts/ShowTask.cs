using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowTask : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private GameObject taskCanvas;
    [SerializeField] private Transform panel;
    [SerializeField] private GameObject standardTask;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && player.enabled)
        {
            if (panel.childCount == 1) standardTask.SetActive(true);
            else standardTask.SetActive(false);
            taskCanvas.SetActive(true);
        }
        else if (taskCanvas.activeSelf) taskCanvas.SetActive(false);
    }
}
