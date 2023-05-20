using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMagnet : MonoBehaviour
{
    [SerializeField] private float yDelta;
    [SerializeField] private RectTransform magnetTransform;
    private void Start()
    {
        magnetTransform.Rotate(new Vector3(yDelta, 0, 0));
    }
}
