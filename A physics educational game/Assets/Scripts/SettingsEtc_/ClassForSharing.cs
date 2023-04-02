using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassForSharing : MonoBehaviour
{
    public string basicResolution = "1280x720";
    public int basicPercent = 20;
    public float basicTextSpeed = 0.1f;
    public float basicVolume = 0.12f;

    public (int Width, int Height) ParseResolution(string resolution)
    {
        var pair = resolution.Split("x");
        return (int.Parse(pair[0]), int.Parse(pair[1]));
    }
}
