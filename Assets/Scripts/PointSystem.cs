using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointSystem : MonoBehaviour
{
    public int lives;
    public GameObject end;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        end.SetActive(false);
    }
    void Update()
    {
        if (lives == 0)
        {
            end.SetActive(true);
        }
    }

    public void Ouch()
    {
        lives--;
        slider.value = lives;
        
    }

}