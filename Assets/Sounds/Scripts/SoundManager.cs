using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public List<AudioClip> musicTracks;
    public List<AudioClip> soundEffects;

    private Dictionary<string, AudioClip> sfxDictionary;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        sfxDictionary = new Dictionary<string, AudioClip>();
        foreach (var clip in soundEffects)
        {
            sfxDictionary[clip.name] = clip;
        }
    }

    public void PlayMusic(int trackIndex = 0, bool loop = true)
    {
        if (trackIndex < 0 || trackIndex >= musicTracks.Count) return;

        musicSource.clip = musicTracks[trackIndex];
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(string sfxName)
    {
        if (sfxDictionary.TryGetValue(sfxName, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
    }
}
