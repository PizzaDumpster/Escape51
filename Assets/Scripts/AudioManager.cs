using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound1[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return; 
        }

        DontDestroyOnLoad(this);

        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(string name)
    {
        Sound1 s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return; 
        s.source.Play();
    }

}
