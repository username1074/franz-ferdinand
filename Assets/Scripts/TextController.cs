using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    List<KeyValuePair<string, bool>> set = new List<KeyValuePair<string, bool>>();
    public Button button1;
    public Button button2;
    public TextMeshProUGUI buttonText1;
    public TextMeshProUGUI buttonText2;

    public PointSystem pointSystem;

    private int curr = 0;

    void Start()
    {
        set.Add(new KeyValuePair<string, bool>("Dog", false));
        set.Add(new KeyValuePair<string, bool>("Cat", true));
        
        buttonText1 = button1.GetComponentInChildren<TextMeshProUGUI>();
        buttonText2 = button2.GetComponentInChildren<TextMeshProUGUI>();

        // Set initial text
        UpdateButtons();

        button1.onClick.AddListener(() => ChangeButtonText(button1));
        button2.onClick.AddListener(() => ChangeButtonText(button2));
    }

    void UpdateButtons()
    {
        if (curr < set.Count - 1)
        {
            buttonText1.text = set[curr].Key;
            buttonText2.text = set[curr + 1].Key;
        }
        else
        {
            buttonText1.text = "";
            buttonText2.text = "";
        }
    }

    public void ChangeButtonText(Button button)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        string currLabel = buttonText.text;

        foreach (var pair in set)
    {
        if (pair.Key == currLabel)
        {
            Debug.Log($"You clicked '{currLabel}', value is: {pair.Value}");
                if (pair.Value == false)
                    pointSystem.lives--;
            break;
        }
    }

        curr += 2; 

        UpdateButtons();
    }
}
