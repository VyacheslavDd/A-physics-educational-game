using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForTest : MonoBehaviour
{
    [SerializeField] private PlayerControl control;
    [SerializeField] private BoxCollider2D playerCollider;

    [SerializeField] private TestTaskManager taskManager;

    [SerializeField] private TriggerDialog dialogWithTeacher;
    [SerializeField] private TriggerDialog baseDialogWithTeacher;

    [SerializeField] private TextAsset restartStory;
    [SerializeField] private List<TextAsset> hints;

    int tryCount = 0;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            dialogWithTeacher.gameObject.SetActive(false);
            control.enabled= false;
            playerCollider.enabled= false;

            dialogWithTeacher.UpdateStory(hints[tryCount]);
            if (baseDialogWithTeacher == null) dialogWithTeacher.UpdateScriptAfter(gameObject);
            else
            {
                baseDialogWithTeacher.UpdateStory(restartStory);
                baseDialogWithTeacher.UpdateScriptAfter(gameObject);
            }
            tryCount++;

            if (tryCount >= hints.Count) tryCount = 0;

            taskManager.FormStateSequence();
            taskManager.transform.parent.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
