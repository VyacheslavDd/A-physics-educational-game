using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftTrigger : MonoBehaviour
{
    private int currentBrightLevel;

    [SerializeField] private SunController controller;
    [SerializeField] private Image lamp;

    public int InteractionsDone = 0;

    private void Start()
    {
        currentBrightLevel = 255;
    }

    private IEnumerator ChangeLampBrightness(int value)
    {
        while (value > 0 && currentBrightLevel < 255 || value < 0 && currentBrightLevel > 0)
        {
            currentBrightLevel += value;
            lamp.color = new Color32(255, 255, (byte)currentBrightLevel, 255);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SunController>() != null)
        {
            StartAffectingOnLamp(collision, -1, false);
        }
    }

    private void StartAffectingOnLamp(Collider2D collision, int value, bool canMove)
    {
        InteractionsDone++;
        StopAllCoroutines();
        StartCoroutine(ChangeLampBrightness(value));
        collision.GetComponent<SunController>().CanMoveLeft = canMove;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<SunController>() != null)
        {
            StartAffectingOnLamp(collision, 1, true);
        }
    }
}
