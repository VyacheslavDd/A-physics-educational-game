using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvases : MonoBehaviour
{
    [SerializeField] private GameObject canvasOff;
    [SerializeField] private GameObject canvasOn;
    [SerializeField] private bool escapable;

    private MenuButtonColorChange change;

    private void Start()
    {
        change = GetComponent<MenuButtonColorChange>();
    }

    public void Switch()
    {
        canvasOff.SetActive(false);
        canvasOn.SetActive(true);
    }

    public void Update()
    {
        if (escapable && Input.GetKeyDown(KeyCode.Escape))
        {
            change.SetStandardText();
            Switch();
        }
    }
}
