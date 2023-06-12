using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnDropdownTaskSelect : MonoBehaviour
{
    private RightDropdownValueChecker checker;
    private TMP_Dropdown dropdown;

    [SerializeField] private TestTaskManager manager;
    [SerializeField] private GameObject resource;

    private void Start()
    {
        checker = GetComponent<RightDropdownValueChecker>();
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private IEnumerator AfterSelection()
    {
        dropdown.interactable = false;
        yield return new WaitForSeconds(1f);
        var answer = dropdown.value;
        dropdown.value = -1;
        resource.SetActive(false);
        if (answer == checker.RightValue) manager.ProcedeToNextPage(true);
        else manager.ProcedeToNextPage(false);
    }

    public void OnOptionSelect()
    {
        if (dropdown.interactable)
            StartCoroutine(AfterSelection());
    }
}
