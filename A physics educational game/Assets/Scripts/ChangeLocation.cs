using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLocation : MonoBehaviour
{
    [SerializeField] private Button changeLocation;
    [SerializeField] public Vector3 position;

    private void UpdateStatus(Collider2D collision, bool status)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            changeLocation.gameObject.SetActive(status);
            changeLocation.GetComponent<TeleportPlayer>().position = position;
            Cursor.visible = status;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        UpdateStatus(collision, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UpdateStatus(collision, false);
    }
}
