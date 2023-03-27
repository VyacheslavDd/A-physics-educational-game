using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCoroutine : MonoBehaviour
{
    public IEnumerator DoInfoCoroutine(GameObject text, float seconds)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(seconds);
        text.SetActive(false);
    }
}
