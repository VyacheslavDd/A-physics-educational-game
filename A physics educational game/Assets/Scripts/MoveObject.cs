using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform grid;

    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject taskCanvas;
    [SerializeField] private PlayerControl control;

    [SerializeField] private Vector3 finishPosition;
    [SerializeField] private Vector3 step;

    private Vector3 initialPosition;
    private bool moveToFinish = true;

    private void Start()
    {
        initialPosition = grid.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null && control.enabled && !taskCanvas.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                grid.position += step;
                if (Vector3.Distance(grid.position, moveToFinish ? finishPosition : initialPosition) < 0.03f)
                {
                    moveToFinish = !moveToFinish;
                    step *= -1;
                }
            }
        }
    }
}
