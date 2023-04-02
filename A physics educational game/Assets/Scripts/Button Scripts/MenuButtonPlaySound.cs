using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonPlaySound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioSource source;

    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioSource additional;
    [SerializeField] private ClassForSharing shareClass;

    public void OnPointerClick(PointerEventData eventData)
    {
        additional.clip = clickClip;
        additional.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        source.clip = pointClip;
        source.Play();
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var volume = shareClass.basicVolume * (PlayerPrefs.GetFloat("sound", shareClass.basicPercent) / 100);
        source.volume = volume;
    }
}
