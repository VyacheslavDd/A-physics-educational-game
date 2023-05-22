using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBadSequenceInResult : MonoBehaviour
{
    [SerializeField] private GameObject nextScript;
    [SerializeField] private ShowResult fukoTaskResult;

    private void Start()
    {
        fukoTaskResult.UpdateNotIdealScript(nextScript);
    }
}
