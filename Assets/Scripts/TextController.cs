using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextController : MonoBehaviour
{
    private List<SpriteType> set;

    public Button button1;
    public Button button2;
    public TextMeshProUGUI buttonText1;
    public TextMeshProUGUI buttonText2;
    public TextMeshProUGUI instructions;

    public ImageController imageController;

    public PointSystem pointSystem;

    System.Random r = new System.Random();

    private int curr = 0;

    private bool swap;

    void Start()
    {
        set = imageController.SpriteTypes;
        buttonText1 = button1.GetComponentInChildren<TextMeshProUGUI>();
        buttonText2 = button2.GetComponentInChildren<TextMeshProUGUI>();
        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (curr >= set.Count)
        {
            instructions.text = "Finished!";
            button1.interactable = false;
            button2.interactable = false;
            return;
        }

        imageController.SetCategory(set[curr].category);
        imageController.NextImage();

        swap = r.Next(0, 2) == 1;
        if (swap)
        {
            buttonText1.text = set[curr].category;
            buttonText2.text = set[curr].option;
            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();
            button1.onClick.AddListener(OnTrueClick);
            button2.onClick.AddListener(OnFalseClick);
        }
        else
        {
            buttonText1.text = set[curr].option;
            buttonText2.text = set[curr].category;
            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();
            button1.onClick.AddListener(OnFalseClick);
            button2.onClick.AddListener(OnTrueClick);
        }

        instructions.text = "Identify the " + set[curr].category;

    }
    void OnTrueClick()
    {
        Debug.Log(true);
        curr++;
        UpdateButtons();
    }

    void OnFalseClick()
    {
        Debug.Log(false);
        curr++;
        pointSystem.lives--;
        UpdateButtons();
    }
}
