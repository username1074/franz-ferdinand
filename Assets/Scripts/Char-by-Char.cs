using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharbyChar : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public string message;
    private int n = 0;
    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        TypeCharacter();
    }

    public void TypeCharacter()
    {
        if (n <= message.Length - 1)
        {
            if (time >= 0.05f)
            {
                time = 0;
                textBox.text += message.ToCharArray().GetValue(n).ToString();
                if (message.ToCharArray().GetValue(n).ToString() == ":")
                {
                    textBox.text += "\n";
                }
                n++;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }

    public void ClearTextBox()
    {
        n = 0;
        textBox.text = string.Empty;
    }

    //public void SetTextBox(string text)
    //{
    //    textBox.text = string.Empty;
    //}
}
