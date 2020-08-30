using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SndManager : MonoBehaviour
{
    static public SndManager instance;
    List<AudioSource> audioSources;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        audioSources = new List<AudioSource>();    
    }

    public void PlaySound(AudioClip sound)
    {
        
        AudioSource audioSource = NewSoundObject();
        audioSource.clip = sound;
        audioSource.Play();
    }
    AudioSource NewSoundObject()
    {
        foreach(AudioSource audio in audioSources)
        {
            if(!audio.isPlaying)
            {
                return audio;
            }
        }
        GameObject gObject = new GameObject();
        AudioSource audioSource = gObject.AddComponent<AudioSource>();

        audioSources.Add(audioSource);

        return audioSource;
    }
}
