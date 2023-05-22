using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForTest : MonoBehaviour
{
    [SerializeField] private PlayerControl control;
    [SerializeField] private BoxCollider2D playerCollider;

    [SerializeField] private FukoTaskManager fukoTaskManager;

    [SerializeField] private TriggerDialog dialogWithTeacher;
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
            dialogWithTeacher.UpdateScriptAfter(gameObject);
            tryCount++;
            if (tryCount == hints.Count) tryCount = 0;
            fukoTaskManager.FormStateSequence();
            gameObject.SetActive(false);
        }
    }
}
