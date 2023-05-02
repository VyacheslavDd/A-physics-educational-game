using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSaveLoadScript : MonoBehaviour
{
    [SerializeField] private GameObject script;
    [SerializeField] private bool setOnStart;

    private void Start()
    {
        if (setOnStart)
        {
            PlayerPrefs.SetString("Last Save", script == null ? string.Empty : script.name);
        }
    }

    public void SetScript()
    {
        PlayerPrefs.SetString("Last Save", script == null ? string.Empty : script.name);
    }
}
