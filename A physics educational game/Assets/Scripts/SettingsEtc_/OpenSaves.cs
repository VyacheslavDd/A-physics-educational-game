using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSaves : MonoBehaviour
{
    [SerializeField] private List<GameObject> saves;

    private void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Level"); i++)
        {
            var save = saves[i].transform;
            save.GetChild(1).GetComponent<Button>().interactable = true;
            save.GetChild(0).gameObject.SetActive(true);
        }
    }
}
