using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateInReading : MonoBehaviour
{
    [SerializeField] private Transform book;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject prevButton;

    private int currentPage;
    private int maxPage;

    private void Start()
    {
        maxPage = book.childCount;
        UpdateButtonsVisibility();
    }

    private void UpdateButtonsVisibility()
    {
        if (currentPage == 0) prevButton.SetActive(false);
        if (currentPage > 0) prevButton.SetActive(true);
        if (currentPage + 1 < maxPage) nextButton.SetActive(true);
        if (currentPage + 1 == maxPage) nextButton.SetActive(false);
    }

    private void SwitchPages(bool goNext=true)
    {
        book.GetChild(currentPage).gameObject.SetActive(false);
        currentPage += (goNext ? 1 : -1);
        book.GetChild(currentPage).gameObject.SetActive(true);
    }

    public void Next()
    {
        SwitchPages();
        UpdateButtonsVisibility();
    }

    public void Previous()
    {
        SwitchPages(goNext:false);
        UpdateButtonsVisibility();
    }
}
