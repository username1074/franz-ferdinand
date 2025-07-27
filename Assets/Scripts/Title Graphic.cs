using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TitleGraphic : MonoBehaviour
{
    public GameObject canvasElement;
    public TextMeshProUGUI console;
    private string[] fullText;
    private int position;
    private float timer;
    private int currentChar;
    private ArrayList lines;
    private float speed;
    public int length;
    private string file = "bootup.txt";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadTextFile());
        position = 0;
        timer = 0f;
        currentChar = 0;
        console.text = "";
        lines = new ArrayList();
    }
    IEnumerator LoadTextFile()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, file);
        UnityWebRequest www = UnityWebRequest.Get(filePath);
        yield return www.SendWebRequest();
        
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Failed to load file: {www.error}");
            yield break;
        }
        fullText = www.downloadHandler.text.Split('\n');
    }

    void Update()
    {

        if (fullText != null && position >= fullText.Length)
        {
            // print(position);                       /** Debug Code for stop condition
            // print(fullText.Length);            *   checks to see where position is at along with the length of the fullText array
            // print(fullText.ToString());      */  
            if (Input.anyKeyDown)
            {
                canvasElement.SetActive(false);
            }
            return;
        }

        timer += Time.deltaTime;

        if (timer >= speed && position < fullText.Length) // T
        {
            if (position >= 3) // This Ensures that any space that contains "###" will be skipped
            {
                if (fullText[position].Contains("###"))
                {
                    position++;
                    timer = 0f;
                    return;
                }
                else if (fullText[position - 1].Contains("###") && !fullText[position].Contains("###"))
                {
                    lines.Clear();
                }
            }
            if (currentChar <= fullText[position].Length-1) // This ensures that the current character index does not exceed the length of the string
            {
                if (position >= 32 && position <= 67) // This ensures that the text within 32 - 67 inclusive are printed via lines instead of characters
                {
                    speed = 0.05f;
                    lines.Add(fullText[position]);
                    console.text = lines.ToSeparatedString("\n");
                    position++;
                    currentChar = 0;
                }
                else // This prints character by character
                {
                    speed = 0.05f;
                    currentChar++;
                    console.text = lines.ToSeparatedString("\n") + "\n" + fullText[position].Substring(0, currentChar);
                }
            }
            else // This ensures that when the current character index exceeds the length of the string, it will move to the next line
            {
                lines.Add(fullText[position]);
                position++;
                currentChar = 0;
            }
            if (lines.Count > length)
            {
                lines.RemoveAt(0);
            }
            timer = 0;
        }

    }

}

