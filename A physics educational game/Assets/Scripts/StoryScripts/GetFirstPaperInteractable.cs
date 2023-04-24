using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFirstPaperInteractable : MonoBehaviour
{
    [SerializeField] private ReadTheoryPaper paper;

    private void Start()
    {
        paper.isInteractable = true;
    }
}
