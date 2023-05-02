using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtonPlaySound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioSource source;
    private Button button;

    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioSource additional;
    [SerializeField] private ClassForSharing shareClass;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (button.interactable)
        {
            additional.clip = clickClip;
            additional.Play();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable)
        {
            source.clip = pointClip;
            source.Play();
        }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        button = GetComponent<Button>();
    }

    private void Update()
    {
        var volume = shareClass.basicVolume * (PlayerPrefs.GetFloat("sound", shareClass.basicPercent) / 100);
        source.volume = volume;
    }
}
