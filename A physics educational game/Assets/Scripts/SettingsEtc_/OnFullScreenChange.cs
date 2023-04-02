using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnFullScreenChange : MonoBehaviour
{
    [SerializeField] private Toggle isFull;

    private void Start()
    {
        isFull.isOn = PlayerPrefs.GetInt("isFull", 1) == 1;
    }

    public void ChangeScreenState()
    {
        PlayerPrefs.SetInt("isFull", isFull.isOn ? 1 : 0);
    } 
}
