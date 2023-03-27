using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    [SerializeField] private TriggerDialog dialogTrigger;
    [SerializeField] private GameObject scriptAfter;
    [SerializeField] private List<GameObject> afterDone;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (scriptAfter != null) dialogTrigger.UpdateScriptAfter(scriptAfter);
            foreach (var item in afterDone) item.SetActive(true);
            Destroy(gameObject);
        }
    }
}
