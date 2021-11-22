using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;
public class AudioManager : MonoBehaviour
{

    #region Singleton
    public static AudioManager instance;
    AudioManager()
    {
        instance = this;
    }
    #endregion
    [OnValueChanged("SavePrefs")]
    public float MusicVolume = 50;
    [OnValueChanged("SavePrefs")]
    public float SfxVolume = 50;

    public Sound[] OSTs;
    public Sound[] SFX;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume") || !PlayerPrefs.HasKey("SfxVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 50);
            PlayerPrefs.SetFloat("SfxVolume", 50);
        }
    }

    private void FixedUpdate()
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        SfxVolume = PlayerPrefs.GetFloat("SfxVolume");
    }


    public void Play(string name)
    {

        Sound s = Array.Find(OSTs, Sound => Sound.Name == name);


        if (s == null)
        {
            Debug.Log("\"" + name + "\"" + " could not be found");
            return;
        }
        s.source.volume = MusicVolume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }
    public void PlaySfx(string name)
    {

        Sound s = Array.Find(SFX, Sound => Sound.Name == name);


        if (s == null)
        {
            Debug.Log("\"" + name + "\"" + " could not be found");
            return;
        }
        s.source.volume = SfxVolume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("SfxVolume", SfxVolume);
    }
    public void LoadPrefs()
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        SfxVolume = PlayerPrefs.GetFloat("SfxVolume");
    }
}
