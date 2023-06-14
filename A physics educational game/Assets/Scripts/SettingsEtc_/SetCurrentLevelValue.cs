using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentLevelValue : MonoBehaviour
{
    public int CurrentLevelValue;

    public void SetValue()
    {
        PlayerPrefs.SetInt("curLevel", CurrentLevelValue);
    }
}
