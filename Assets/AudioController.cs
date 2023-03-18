using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource source;

    private void Awake()
    {
        source= GetComponent<AudioSource>();    
    }

    private void Update()
    {
        // If the audio source has stopped playing, destroy it
        if (!source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Loads an AudioClip and sets it as the clip of the audio source
    /// </summary>
    /// <param name="clipName"></param>
    public void LoadClip(string clipName)
    {
        // We will try to find an asset of type AudioClip from the
        // Resources folder, then the Audio folder
        // Resources/Audio/x.mp3/.wav
        source.clip = Resources.Load<AudioClip>("Audio/" + clipName);
        gameObject.name = "audio_" + clipName;
        source.Play();
    }

    //Add support for looping
}
