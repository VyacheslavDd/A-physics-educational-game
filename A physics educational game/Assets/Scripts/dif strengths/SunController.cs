using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    private RectTransform rectTransform;

    [SerializeField] private float moveSpeed;

    public bool CanMoveLeft;
    public bool CanMoveRight;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && CanMoveLeft)
            rectTransform.localPosition += new Vector3(-moveSpeed, 0, 0);
        if (Input.GetKey(KeyCode.D) && CanMoveRight)
            rectTransform.localPosition += new Vector3(moveSpeed, 0, 0);
    }
}
