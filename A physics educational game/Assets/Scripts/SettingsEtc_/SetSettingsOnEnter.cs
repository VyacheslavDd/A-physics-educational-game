using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSettingsOnEnter : MonoBehaviour
{
    [SerializeField] private bool isMenu;
    [SerializeField] private AudioSource cameraSource;
    private ClassForSharing shareClass;

    private void Start()
    {
        if (!Cursor.visible) Cursor.visible = true;
        shareClass = GetComponent<ClassForSharing>();
        var resolution = PlayerPrefs.GetString("resolution", shareClass.basicResolution);
        var fullScreenCheck = PlayerPrefs.GetInt("isFull", 1);
        var musicVolume = PlayerPrefs.GetFloat("music", shareClass.basicPercent);


        SetPrefs(resolution, fullScreenCheck == 1 ? true : false, musicVolume);
    }

    private void SetPrefs(string resolution, bool fullscreen, float musicVolume)
    {
        (var width, var height) = shareClass.ParseResolution(resolution);
        if (isMenu) Screen.SetResolution(width, height, fullscreen);
        cameraSource.volume = shareClass.basicVolume * (musicVolume / 100);
    }
}
