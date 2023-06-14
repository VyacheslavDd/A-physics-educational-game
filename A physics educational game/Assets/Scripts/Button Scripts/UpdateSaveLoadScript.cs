using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSaveLoadScript : MonoBehaviour
{
    [SerializeField] private GameObject script;
    [SerializeField] private bool setOnStart;

    private void UpdateCurrentLevel()
    {
        var parent = script.transform.parent;

        var counter = 0;
        for (int i = 0; i < parent.childCount; i++)
        {
            var child = parent.GetChild(i);
            if (child.GetComponent<OpenScriptsWhenCalled>() != null) counter++;
            if (child.name == script.name)
            {
                PlayerPrefs.SetInt("curLevel", counter);
                return;
            }
        }
    }

    private void SetNewSave()
    {

        PlayerPrefs.SetString("Last Save", script == null ? string.Empty : script.name);
        if (script == null) PlayerPrefs.SetInt("curLevel", 0);
        else UpdateCurrentLevel();

        if (PlayerPrefs.GetInt("Level") < PlayerPrefs.GetInt("curLevel"))
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("curLevel"));
    }

    private void Start()
    {
        if (setOnStart)
        {
            SetNewSave();
        }
    }

    public void SetScript()
    {
        SetNewSave();
    }
}
