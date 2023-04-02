using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color pointedColor;

    private TextMeshProUGUI text;
    private Color usualColor;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        usualColor = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = pointedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = usualColor;
    }

    public void SetStandardText()
    {
        text.color = usualColor;
    }
}
