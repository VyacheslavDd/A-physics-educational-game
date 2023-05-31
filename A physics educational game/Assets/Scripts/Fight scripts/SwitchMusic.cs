using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip music;

    private void Start()
    {
        StartCoroutine(ChangeMusic());
    }

    private IEnumerator ChangeMusic()
    {
        var volume = source.volume;
        while (source.volume > 0)
        {
            source.volume -= 0.005f;
            yield return new WaitForSeconds(0.05f);
        }
        source.clip = music;
        source.Play();
        while (source.volume < volume)
        {
            source.volume += 0.005f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
