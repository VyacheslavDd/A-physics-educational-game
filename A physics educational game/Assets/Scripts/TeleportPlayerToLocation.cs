using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TeleportPlayerToLocation : MonoBehaviour
{
    [SerializeField] private Vector3 teleportPos;
    [SerializeField] private GameObject infoText;
    [SerializeField] private GameObject teleportPanel;
    [SerializeField] private GameObject[] gridsToOff;
    [SerializeField] private GameObject[] gridsToOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            infoText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null && Input.GetKey(KeyCode.F) && !teleportPanel.activeSelf)
        {
            teleportPanel.SetActive(true);
            StartCoroutine(MakeTransitionBetween(collision.GetComponent<PlayerControl>()));
        }
    }

    private void ChangeObjectsState(GameObject[] objs, bool state)
    {
        foreach (var obj in objs)
            obj.SetActive(state);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        infoText.SetActive(false);
    }

    private IEnumerator MakeTransitionBetween(PlayerControl player)
    {
        infoText.SetActive(false);
        yield return new WaitForSeconds(1);
        player.enabled = false;
        player.transform.position = teleportPos;
        ChangeObjectsState(gridsToOff, false);
        ChangeObjectsState(gridsToOn, true);
        yield return new WaitForSeconds(0.5f);
        player.enabled = true;
        teleportPanel.SetActive(false);
    }
}
