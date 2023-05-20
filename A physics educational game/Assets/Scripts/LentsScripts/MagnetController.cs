using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    public bool IsHeld { get; set; }

    private RectTransform rectTransform;
    [SerializeField] private float moveSpeed = 5;

    private bool canHold;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rectTransform.localPosition += new Vector3(0, moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rectTransform.localPosition += new Vector3(0, -moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rectTransform.localPosition += new Vector3(-moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rectTransform.localPosition += new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.E) && canHold)
        {
            IsHeld = true;
        }
        if (!Input.GetKey(KeyCode.E))
        {
            IsHeld = false;
        }
    }

    public void EnablePossibilityToHold()
    {
        canHold = true;
    }
}
