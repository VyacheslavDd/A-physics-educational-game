using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlAnswerInput : MonoBehaviour
{
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;
    [SerializeField] private GameObject image;

    [SerializeField] private TestTaskManager fukoTaskManager;

    private bool canPress = true;

    private RightState rightState;

    private void Start()
    {
        rightState = GetComponent<RightState>();
    }

    private IEnumerator CheckAndAwaitBeforeContinuing(GameObject button, bool pressedRightAnswer)
    {
        canPress = false;
        var buttonComponent = button.GetComponent<TextMeshProUGUI>();
        buttonComponent.color = new Color32(255, 184, 0, 255);

        yield return new WaitForSeconds(1f);

        buttonComponent.color = new Color32(237, 255, 0, 255);

        canPress = true;
        if (image != null) image.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);

        if (pressedRightAnswer && rightState != null || !pressedRightAnswer && rightState == null) fukoTaskManager.ProcedeToNextPage(true);
        else fukoTaskManager.ProcedeToNextPage(false);

        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && canPress)
        {
            StartCoroutine(CheckAndAwaitBeforeContinuing(yesButton, true));
        }
        else if (Input.GetKeyDown(KeyCode.N) && canPress)
        {
            StartCoroutine(CheckAndAwaitBeforeContinuing(noButton, false));
        }
    }
}
