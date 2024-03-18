using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_InputField))]
public class NameInputField : MonoBehaviour, ISubmitHandler
{
    private TMP_InputField inputField;
    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }
    
    

    public void OnSubmit(BaseEventData eventData)
    {
        if (inputField.text == "")
        {
            Debug.Log("Name cannot be empty");
            inputField.Select();
            inputField.ActivateInputField();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
