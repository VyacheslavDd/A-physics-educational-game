using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowState : MonoBehaviour
{
    [SerializeField] private string stateText;

    [SerializeField] private TextMeshProUGUI state;

    [SerializeField] private GameObject image;
    [SerializeField] private List<GameObject> choices;

    [SerializeField] private TypeCoroutine typeCoroutine;

    private ControlAnswerInput controlInput;

    private void Start()
    {
        controlInput = gameObject.GetComponent<ControlAnswerInput>();
    }

    public IEnumerator DisplayState()
    {
        foreach (var choice in choices)
        {
            if (choice.activeSelf) choice.SetActive(false);
        }

        if (controlInput != null && controlInput.enabled) controlInput.enabled = false;
        state.text = "";
        StartCoroutine(typeCoroutine.TypeText(state, stateText));
        yield return new WaitForSeconds(3f);
        if (image != null) image.SetActive(true);
        yield return new WaitForSeconds(1f);
        foreach (var choice in choices)
        {
            choice.SetActive(true);
            yield return new WaitForSeconds(1f);
            var btn = choice.GetComponent<Button>();
            var dropdown = choice.GetComponent<TMP_Dropdown>();
            if (btn != null) btn.interactable = true;
            if (dropdown != null) dropdown.interactable = true;
        }
        if (controlInput != null) controlInput.enabled = true;
    }
}
