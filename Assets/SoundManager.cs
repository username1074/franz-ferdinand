using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Allows other scripts to call functions from the SoundManager
    public static SoundManager instance = null;

    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    [field: SerializeField] public AudioClip bgSounds { get; set; }

    [field: SerializeField] public AudioClip startUp { get; set; }

    [field: SerializeField] public AudioClip success { get; set; }

    [field: SerializeField] public AudioClip mistake { get; set; }

    [field: SerializeField] public AudioClip failure { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Play(startUp);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }
    
    // Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

}
