using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private PlayerControl control;
    [SerializeField] private NPCBehaviour playerBehaviour;
    [SerializeField] private PauseGame pause;
    [SerializeField] private StartLoading loading;

    [SerializeField] private AudioSource music;

    [SerializeField] private GameObject endCanvas;

    [SerializeField] private List<Transform> directionAfter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            Cursor.visible = true;
            StartCoroutine(StopMusic());
            control.ResetAnimations();
            control.enabled = false;
            pause.enabled = false;
            playerBehaviour.enabled = true;
            playerBehaviour.UpdatePointsToGo(directionAfter);
            StartCoroutine(InfoAndLoadingCoroutine());
        }
    }

    private IEnumerator InfoAndLoadingCoroutine()
    {
        endCanvas.SetActive(true);  
        yield return new WaitForSeconds(4f);
        loading.StartLoadingScene();
    }

    private IEnumerator StopMusic()
    {
        while (music.volume > 0)
        {
            music.volume -= 0.001f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
