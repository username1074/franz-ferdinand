using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TitleGraphic : MonoBehaviour
{
    public TextMeshProUGUI console;
    private string[] fullText;
    private int position;
    private float timer;
    private int currentChar;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        fullText = File.ReadAllLines("Assets/Text/start-up.txt");
        position = 0;
        timer = 0f;
        currentChar = 0;
        console.text = "";
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        ArrayList lines = new ArrayList(); // Make prior lines stored in an ArrayList
        if (!done)
        {
            timer += Time.deltaTime;
            if (timer >= 0.075f)
            {
                if (currentChar < fullText[position].Length)
                {
                    console.text = fullText[position].Substring(0, currentChar + 1);
                    currentChar++;
                }
                else
                {
                    currentChar = 0;
                    position++;
                    if (position >= fullText.Length)
                    {
                        done = true;
                    }
                }
                timer = 0;
            }
        }

    }

    IEnumerator WriteWords(string line)
    {
        string words = "";
        foreach (char c in line)
        {
            words += c;
            console.SetText(words);
            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
}
