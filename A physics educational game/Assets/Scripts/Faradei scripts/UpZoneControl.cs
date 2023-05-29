using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpZoneControl : MonoBehaviour
{
    [SerializeField] private MandrelController mandrelController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MandrelController>() != null)
        {
            mandrelController.CanMoveUp = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MandrelController>() != null)
        {
            mandrelController.CanMoveUp = true;
        }
    }
}
