using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Vector3 position;
    [SerializeField] private GameObject player;

    public void Teleport()
    {
        player.transform.position = position;
    }
}
