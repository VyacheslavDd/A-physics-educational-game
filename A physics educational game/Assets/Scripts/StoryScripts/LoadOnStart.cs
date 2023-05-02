using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnStart : MonoBehaviour
{
    private void Start()
    {
        var scriptName = PlayerPrefs.GetString("Last Save");
        if (scriptName != string.Empty)
        {
            var obj = GameObject.Find(scriptName);
            try
            {
                obj.GetComponent<OpenScriptsWhenCalled>().DoLoading();
            }
            catch
            {

            }
        }
    }
}
