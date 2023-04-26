using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAbilityToPickUpKeys : MonoBehaviour
{
    private void Start()
    {
        var keys = FindObjectsOfType<Key>();
        foreach (var key in keys)
        {
            key.CanPickUp = true;
        }
    }
}
