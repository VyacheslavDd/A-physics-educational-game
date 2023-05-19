using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIfMagnetGoneTooFar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.GetComponent<MagnetController>() != null)
        {
            collision.transform.parent.localPosition = new Vector3(328, -129, -251);
        }
    }
}
