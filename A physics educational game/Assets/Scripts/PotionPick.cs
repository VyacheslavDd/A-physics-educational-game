using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PotionPick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            var component = collision.GetComponent<PlayerSpeedEffect>();
            component.SendMessage("RefillEffect");
            component.enabled = true;
            Destroy(gameObject);
        }
    }
}
