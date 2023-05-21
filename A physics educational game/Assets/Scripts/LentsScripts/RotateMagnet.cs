using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMagnet : MonoBehaviour
{
    [SerializeField] private MagnetController magnetController;
    [SerializeField] private bool isRotated;
    private void Start()
    {
        magnetController.IsRotated = isRotated;
    }
}
