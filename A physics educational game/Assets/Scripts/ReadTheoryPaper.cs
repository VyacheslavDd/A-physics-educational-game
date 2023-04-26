using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTheoryPaper : MonoBehaviour
{
    [SerializeField] private GameObject theoryCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private PlayerControl control;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private Image readMention;

    public bool isInteractable;

    private bool isReading;
    private bool isIn;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null && isInteractable && !dialogCanvas.activeSelf)
        {
            if (!isReading) readMention.gameObject.SetActive(true);
            else readMention.gameObject.SetActive(false);

            isIn = true;
        }
        else isIn = false;
    }

    private void InteractWithPaper()
    {
        isReading = !isReading;
        Cursor.visible = isReading;
        theoryCanvas.SetActive(isReading);
        control.enabled = !isReading;
        control.ResetAnimations();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        readMention.gameObject.SetActive(false);
        isReading = false;
        isIn = false;
    }

    private void Update()
    {
        if (dialogCanvas.activeSelf && theoryCanvas.activeSelf) 
        {
            theoryCanvas.SetActive(false);
            Cursor.visible = false;
        };
        if (Input.GetKeyDown(KeyCode.E) && isIn && !pauseCanvas.activeSelf) InteractWithPaper();
    }
}
