using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrigger : MonoBehaviour
{
    [SerializeField] private SunController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SunController>() != null)
        {
            collision.GetComponent<SunController>().CanMoveRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<SunController>() != null)
        {
            collision.GetComponent<SunController>().CanMoveRight = true;
        }
    }
}
