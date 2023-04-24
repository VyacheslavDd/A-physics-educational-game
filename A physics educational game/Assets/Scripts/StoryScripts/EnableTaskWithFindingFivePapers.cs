using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTaskWithFindingFivePapers : MonoBehaviour
{
    [SerializeField] private HandlePapers papers;

    [SerializeField] private GameObject papersUI;

    [SerializeField] private GameObject paperGrids;

    private void Start()
    {
        papers.allowedToMoveObjects = true;
        papersUI.SetActive(true);
        paperGrids.SetActive(true);
    }
}
