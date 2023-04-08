using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScriptAfterMonologue : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject exitBound;
    [SerializeField] private GameObject cannotQuit;
    [SerializeField] private GameObject initialDialog;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private AudioClip foneClip;
    [SerializeField] private AudioSource cameraListener;

    [SerializeField] private PauseGame pauseGame;
    [SerializeField] private PlayerControl control;
    [SerializeField] private NPCBehaviour playerBehaviour;
    [SerializeField] private List<GameObject> playerPointsToGo;

    [SerializeField] private GameObject dialogCanvas;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null && !dialogCanvas.activeSelf)
        {
            initialDialog.SetActive(false);
            startCanvas.SetActive(false);
            exitBound.SetActive(true);
            cannotQuit.SetActive(true);
            cameraListener.clip = foneClip;
            cameraListener.Play();
            playerBehaviour.enabled = false;
            control.enabled = true;
            pauseGame.enabled = true;

            foreach (var point in playerPointsToGo) Destroy(point);
            StartCoroutine(ChangeCameraSize());
        }
    }

    private IEnumerator ChangeCameraSize()
    {
        while (mainCamera.orthographicSize < 6.02f)
        {
            mainCamera.orthographicSize += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }

}
