using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterAtPoint : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        character.position = spawnPoint.position;
    }
}
