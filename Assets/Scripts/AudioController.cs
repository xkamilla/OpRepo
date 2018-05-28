using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource musicSource;

    public AudioSource soundSource;
    public AudioClip[] allMusic;
    public AudioClip[] allSounds;

    void Awake()
    {
        musicSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayMusic(string key)
    {
        switch (key)
        {
            case "start":
                musicSource.clip = allMusic[0];
                break;
            case "city":
                musicSource.clip = allMusic[1];
                break;
            case "end":
                musicSource.clip = allMusic[2];
                break;
            default:
                Debug.Log("No music");
                break;
        }
        musicSource.Play();
    }
    public void StopMusic()
    {
        StartCoroutine(FadeOut(musicSource, 2.0f));
        musicSource.Stop();
    }
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public void PlayAudio(string key)
    {
        if(key == "whistle")
        {
            soundSource.loop = false;
        }
        else
        {
            soundSource.loop = true;
        }
        switch(key)
        {
            case "alley":
                soundSource.clip = allSounds[0];
                break;
            case "ambiance":
                soundSource.clip = allSounds[1];
                break;
            case "people1":
                soundSource.clip = allSounds[2];
                break;
            case "people2":
                soundSource.clip = allSounds[3];
                break;
            case "phone":
                soundSource.clip = allSounds[4];
                break;
            case "portalComb":
                soundSource.clip = allSounds[5];
                break;
            case "portal3":
                soundSource.clip = allSounds[6];
                break;
            case "whistle":
                soundSource.clip = allSounds[7];
                break;
            case "wink":
                soundSource.clip = allSounds[8];
                break;
            default:
                Debug.Log("No sound");
                break;
        }
        soundSource.Play();
    }
    public void StopAudio()
    {
        FadeOut(soundSource, 2.0f);
    }
}
