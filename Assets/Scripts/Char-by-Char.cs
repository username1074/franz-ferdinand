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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (n <= message.Length-1)
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
}
