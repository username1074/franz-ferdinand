using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingSOunds : MonoBehaviour
{
    public AudioClip music;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayMusic(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
