using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int lives;
    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        lives = 1;
        end.SetActive(false);
    }
    void Update()
    {
        if (lives == 0)
        {
            end.SetActive(true);
        }
    }

}
