using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> canvases;
    [SerializeField] private MenuButtonColorChange continueButton;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private PlayerControl player;
    [SerializeField] private AudioSource source;

    private bool paused;

    private void Update()
    {
        if (!Cursor.visible) Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape) && CheckIfCanvasesDisabled())
        {
            if (!paused)
            {
                ChangeStates(true, 0.0f);
                Cursor.visible = true;
                source.Pause();
            }
            else
            {
                Continue();
                return;
            }
            paused = !paused;
        }
    }

    public void Continue()
    {
        ChangeStates(false, 1.0f);
        source.UnPause();
        continueButton.SetStandardText();
        paused = !paused;
        Cursor.visible = false;
    }

    private bool CheckIfCanvasesDisabled()
    {
        return canvases.All(x => !x.activeSelf);
    }

    private void ChangeStates(bool pause, float timeScale)
    {
        Time.timeScale = timeScale;
        pauseCanvas.SetActive(pause);
        player.enabled = !pause;
    }
}
