using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // main game loop, call after opening scene finish once per "day"
    bool GameDay(int Day)
    {
        // initialise counter for #fails
        ///open on black screen and
        // show text instructions, show what day it is
        for (int i = 1; i <= 20; i++)
        {
            ///get image, wait for response (true/false return)
            /// if response is false: inc counter by 1 else do nothing
            /// check fail counter not above x (return false eg. failed day)
        }
        return true;
    }
}
