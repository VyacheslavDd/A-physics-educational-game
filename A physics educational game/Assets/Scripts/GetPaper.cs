using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPaper : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private HandlePapers paperManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            paperManager.CollectPaper();
            Destroy(grid.gameObject);
        }
    }
}
