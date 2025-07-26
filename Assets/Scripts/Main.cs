using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public ImageController imageController;
    public TextController textController;
    // Start is called before the first frame update
    void Start()
    {
        imageController.ChangeImage("Assets/Images/hey babygirl.png");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
