using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public string[] options;
    public Button button;
    public TextMeshProUGUI buttonText;
    private int curr = 0;
    
    void Start()
    {
        // Get the TMP_Text component from the button's child
        // Assuming the TMP_Text is a child of the Button GameObject
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        // Set the initial text (optional)
        if (buttonText != null)
        {
            buttonText.text = options[curr];
        }

        // Add a listener to change text when the button is clicked (example)
        myButton.onClick.AddListener(ChangeButtonText);
    }

    void ChangeButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = options;
        }
    }

}
