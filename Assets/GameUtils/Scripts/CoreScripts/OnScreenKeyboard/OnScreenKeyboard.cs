using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnScreenKeyboard : MonoBehaviour
{

    public InputField textField;
    public GameObject lowerCase, upperCase, symbolsUK, symbolsUSA;
    public bool useUSASymbols = false;

    [Header("Auto Select Button")]
    public GameObject lowerCaseButton;
    public GameObject symbolsUKCaseButton;
    public GameObject symbolsUSACaseButton;
    public bool use1stSelectedItem = false;

    private void Start()
    {
        if (use1stSelectedItem)
        {
            SetFirstItem(lowerCaseButton);
        }
    }

    public void AddCharacter(string character)
    {
        textField.text = textField.text + character;
    }

    public void BackSpace()
    {
        if (textField.text.Length > 0)
        {
            textField.text = textField.text.Remove(textField.text.Length - 1);
        }
    }

    public void CloseAllLayouts()
    {
        lowerCase.SetActive(false);
        upperCase.SetActive(false);
        symbolsUK.SetActive(false);
        symbolsUSA.SetActive(false);
    }

    public void SetSymbols()
    {
        CloseAllLayouts();

        if (useUSASymbols)
        {
            symbolsUSA.SetActive(true);

            if (use1stSelectedItem)
            {
                SetFirstItem(symbolsUSACaseButton);
            }
        }
        else
        {
            symbolsUK.SetActive(true);

            if (use1stSelectedItem)
            {
                SetFirstItem(symbolsUKCaseButton);
            }
        }
    }

    public void SetLayout(GameObject setLayout)
    {
        CloseAllLayouts();
        setLayout.SetActive(true);
    }

    public void ResetLayout()
    {
        CloseAllLayouts();

        lowerCase.SetActive(true);
    }

    public void ClearTextField()
    {
        textField.text = "";
    }

    // Method to set the 1st selected item
    public void SetFirstItem(GameObject selectedItem)
    {
        if (use1stSelectedItem)
        {
            // Null the events system
            EventSystem.current.SetSelectedGameObject(null);
            // Set the first selected menu item
            EventSystem.current.SetSelectedGameObject(selectedItem);
        }


    }
}
