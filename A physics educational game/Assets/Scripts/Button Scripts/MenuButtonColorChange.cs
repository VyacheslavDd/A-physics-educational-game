using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color pointedColor;

    private TextMeshProUGUI text;
    private Button button;
    private Color usualColor;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();
        usualColor = new Color32(255, 251, 85, 255);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable)
            text.color = pointedColor;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (button.interactable)
            text.color = usualColor;
    }

    public void SetStandardText()
    {
        text.color = usualColor;
    }
}
