using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColliderState : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private bool state;
    private void Start()
    {
        boxCollider.enabled = state;
    }
}
