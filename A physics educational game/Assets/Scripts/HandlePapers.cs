using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlePapers : MonoBehaviour
{
    [SerializeField] private List<GameObject> papers;

    private int counter = 0;

    public void CollectPaper()
    {
        if (counter < papers.Count)
        {
            papers[counter].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            counter++;
        }
    }
}
