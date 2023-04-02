using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnResolutionChange : MonoBehaviour
{
    [SerializeField] private ClassForSharing shareClass;
    [SerializeField] private TMP_Dropdown resolutions;

    public void changeResolution()
    {
        var selectedResolution = resolutions.options[resolutions.value].text;
        (int width, int height) = shareClass.ParseResolution(selectedResolution);
        Screen.SetResolution(width, height, PlayerPrefs.GetInt("isFull") == 1 ? true : false);
        PlayerPrefs.SetString("resolution", selectedResolution);
    }
}
