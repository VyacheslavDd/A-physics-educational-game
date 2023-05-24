using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtonPressing : MonoBehaviour
{
    private RightState state;
    private TextMeshProUGUI text;

    [SerializeField] private TestTaskManager testManager;

    private void Start()
    {
        state = GetComponent<RightState>();
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void SetNoInteractability()
    {
        var parent = transform.parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            var child = parent.GetChild(i);
            var btn = child.GetComponent<Button>();
            if (btn != null) btn.interactable = false;
        }
    }

    private IEnumerator CheckAnswer()
    {
        text.color = new Color32(255, 176, 45, 255);
        yield return new WaitForSeconds(1f);
        text.color = new Color32(255, 251, 85, 255);

        var parent = transform.parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            var child = parent.GetChild(i);
            if (!child.name.Contains("Question") && child.gameObject != gameObject) child.gameObject.SetActive(false);
        }

        if (state != null) testManager.ProcedeToNextPage(true);
        else testManager.ProcedeToNextPage(false);

        enabled = false;
    }

    public void Click()
    {
        SetNoInteractability();
        StartCoroutine(CheckAnswer());
    }

    private void Update()
    {
        if (!Cursor.visible) Cursor.visible = true;
    }
}
