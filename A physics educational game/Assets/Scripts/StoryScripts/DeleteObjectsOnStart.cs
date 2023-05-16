using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectsOnStart : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToDelete;

    private void Start()
    {
        foreach (var obj in objectsToDelete)
        {
            if (obj != null)
                Destroy(obj);
        }
    }
}
