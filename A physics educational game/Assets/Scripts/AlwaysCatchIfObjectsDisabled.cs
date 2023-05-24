using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysCatchIfObjectsDisabled : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeDisabled;

    private void Update()
    {
        if (objectToBeDisabled.activeSelf) objectToBeDisabled.SetActive(false);
    }
}
