using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectsOnStart : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    private void Start()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
