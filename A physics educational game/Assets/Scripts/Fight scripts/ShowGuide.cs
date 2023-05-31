using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuide : MonoBehaviour
{
    [SerializeField] private GameObject text;

    private IEnumerator AwaitGuide()
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(AwaitGuide());
    }
}
