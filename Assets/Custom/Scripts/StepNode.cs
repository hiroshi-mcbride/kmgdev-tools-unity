using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(Button))]
public class StepNode : MonoBehaviour, IPointerClickHandler
{
    private Button button;
    private RawImage image;

    private void Awake()
    {
        image = GetComponent<RawImage>();
        button = GetComponent<Button>();
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ColorBlock buttonColors = button.colors;
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                buttonColors.normalColor = Color.black;
                button.colors = buttonColors;
                break;
            case PointerEventData.InputButton.Right:
                buttonColors.normalColor = Color.white;
                button.colors = buttonColors;
                break;
        }
    }
}
