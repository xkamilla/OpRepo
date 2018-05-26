using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource alleySound;
    public AudioSource peopleSound1;
    public AudioSource peopleSound2;
    public AudioSource peopleSoundQuiet;
    public AudioSource phoneCallSound;
    public AudioSource ambiance;
    public AudioSource portal2Sound;
    public AudioSource portal3Sound;
    public AudioSource portalComb;
    public AudioSource whistleSound;
    public AudioSource winkSound;

    AudioSource[] allAudioSources;

    void Awake()
    {
        allAudioSources = FindObjectsOfType<AudioSource>() as AudioSource[];
    }

    public void PlayAudio(string key)
    {
        switch(key)
            {
            case "alley":
                alleySound.Play();
                break;
            case "people1":
                peopleSound1.Play();
                break;
            case "people2":
                peopleSound2.Play();
                break;
            case "peopleQuiet":
                peopleSoundQuiet.Play();
                break;
            case "phone":
                phoneCallSound.Play();
                break;
            case "ambiance":
                ambiance.Play();
                break;
            case "portalComb":
                portalComb.Play();
                break;
            case "portal3":
                portal3Sound.Play();
                break;
            case "wink":
                winkSound.Play();
                break;
            case "whistle":
                whistleSound.Play();
                break;
            default:
                Debug.Log("No sound");
                break;
        }
    } 
    public void StopAudio()
    {
        foreach(AudioSource audio in allAudioSources)
        {
            audio.Stop();
        }
    }
}
