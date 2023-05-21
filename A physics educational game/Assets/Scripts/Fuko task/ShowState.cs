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
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;

    [SerializeField] private TypeCoroutine typeCoroutine;

    private ControlAnswerInput controlInput;

    private void Start()
    {
        controlInput = gameObject.GetComponent<ControlAnswerInput>();
    }

    public IEnumerator DisplayState()
    {
        state.text = "";
        StartCoroutine(typeCoroutine.TypeText(state, stateText));
        yield return new WaitForSeconds(3f);
        if (image != null) image.SetActive(true);
        yield return new WaitForSeconds(1f);
        yesButton.SetActive(true);
        yield return new WaitForSeconds(1f);
        noButton.SetActive(true);
        yield return new WaitForSeconds(1f);
        controlInput.enabled = true;
    }
}
