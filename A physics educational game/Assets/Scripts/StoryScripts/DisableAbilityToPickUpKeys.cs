using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAbilityToPickUpKeys : MonoBehaviour
{
    private void Start()
    {
        var keys = FindObjectsOfType<Key>();
        foreach (var key in keys)
        {
            key.CanPickUp = false;
        }
    }
}
