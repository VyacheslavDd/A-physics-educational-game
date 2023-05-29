using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownZoneControl : MonoBehaviour
{
    [SerializeField] private MandrelController mandrelController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MandrelController>() != null)
        {
            mandrelController.CanMoveDown = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MandrelController>() != null)
        {
            mandrelController.CanMoveDown = true;
        }
    }
}
