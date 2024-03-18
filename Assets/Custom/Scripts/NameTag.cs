using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NameTag : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private TMP_Text NameText;
    [SerializeField] private TMP_InputField NameInputField;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        NameInputField.gameObject.SetActive(true);
        NameInputField.Select();
        NameInputField.ActivateInputField();
    }
    
    public void OnNameInputEnd()
    {
        if (NameInputField.text == "")
        {
            Debug.Log("Name cannot be empty");
            NameInputField.Select();
            NameInputField.ActivateInputField();
        }
        else
        {
            NameText.text = NameInputField.text;
            NameInputField.gameObject.SetActive(false);
        }
    }
}
