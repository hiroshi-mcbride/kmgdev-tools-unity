using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StepButton : MonoBehaviour, IPointerClickHandler
{
    public bool Active
    {
        get => active;
        set
        {
            ColorBlock buttonColors = button.colors;
            buttonColors.normalColor = value ? Color.black : Color.white;
            button.colors = buttonColors;
            active = value;
        }
    }
    private bool active;
    public int Index;
    private Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Active = eventData.button switch
        {
            PointerEventData.InputButton.Left => true,
            PointerEventData.InputButton.Right => false,
            _ => Active
        };
    }
}

