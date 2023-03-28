using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TeleportPlayerToLocation : MonoBehaviour
{
    [SerializeField] private Vector3 teleportPos;
    [SerializeField] private GameObject arrowTeleport;
    [SerializeField] private GameObject teleportPanel;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject[] objectsToOff;
    [SerializeField] private GameObject[] objectsToOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            arrowTeleport.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null && Input.GetKey(KeyCode.F) && !teleportPanel.activeSelf
            && !dialogPanel.activeSelf)
        {
            teleportPanel.SetActive(true);
            StartCoroutine(MakeTransitionBetween(collision.GetComponent<PlayerControl>()));
        }
    }

    private void ChangeObjectsState(GameObject[] objs, bool state)
    {
        foreach (var obj in objs)
        {
            obj.SetActive(state);
            var npcBehaviour = obj.GetComponent<NPCBehaviour>();
            if (npcBehaviour != null && state) npcBehaviour.ContinueWhenEnabledAgain();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        arrowTeleport.SetActive(false);
    }

    private IEnumerator MakeTransitionBetween(PlayerControl player)
    {
        arrowTeleport.SetActive(false);
        yield return new WaitForSeconds(1);
        player.enabled = false;
        player.transform.position = teleportPos;
        ChangeObjectsState(objectsToOff, false);
        ChangeObjectsState(objectsToOn, true);
        yield return new WaitForSeconds(0.5f);
        player.enabled = true;
        teleportPanel.SetActive(false);
    }
}
