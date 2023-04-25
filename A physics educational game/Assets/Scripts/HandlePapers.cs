using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlePapers : MonoBehaviour
{
    [SerializeField] private List<GameObject> papers;
    [SerializeField] private GameObject nextScript;

    public bool allowedToMoveObjects;

    private int counter = 0;

    public void CollectPaper()
    {
        if (counter < papers.Count)
        {
            papers[counter].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            counter++;
            if (counter == papers.Count) FinishPaperTask();
        }
    }

    private void FinishPaperTask()
    {
        papers[0].transform.parent.gameObject.SetActive(false);
        nextScript.SetActive(true);
        var moveableObject = FindObjectsOfType<MoveObject>();
        foreach (var obj in moveableObject)
        {
            obj.ResetPosition();
        }
        allowedToMoveObjects = false;
    }

}
