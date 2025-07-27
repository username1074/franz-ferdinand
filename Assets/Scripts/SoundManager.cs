using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// mainly used the learn.nity sound manager tutorial and "Building a Sound Manager" from Brian Moakley @ Jezner
public class SoundManager : MonoBehaviour
{

    //Allows other scripts to call functions from the SoundManager--> singleton
    public static SoundManager instance = null;

    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    [field: SerializeField] public AudioClip BgSounds { get; set; }

    [field: SerializeField] public AudioClip StartUp { get; set; }

    [field: SerializeField] public AudioClip Correct { get; set; }

    [field: SerializeField] public AudioClip Success { get; set; }

    [field: SerializeField] public AudioClip Mistake { get; set; }

    [field: SerializeField] public AudioClip Failure { get; set; }

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Play(StartUp);
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

        // to use in a component/script:
        // public AudioClip <MusicClip>; as datafield
        // SoundManager.Instance.PlayMusic(<MusicClip>);
    }

    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();

        // to use in component/script:
        // public AudioClip[] <RandomNoises>; as datafield
        // SoundManager.Instance.RandomSoundEffect(<RandomNoises>);
    }

}
