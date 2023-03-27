using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTaskAfterCompleting : MonoBehaviour
{
    public GameObject TaskToDelete;

    private void Start()
    {
        Destroy(TaskToDelete);
    }
}
