using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSideBound : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private OpponentBehaviour opponent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            controller.CanMoveUp = false;
        }
        if (collision.GetComponent<OpponentBehaviour>() != null)
        {
            opponent.ChangeDirection(-1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            controller.CanMoveUp = true;
        }
    }
}
