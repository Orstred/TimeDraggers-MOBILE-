using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{

    #region Singleton
    public static AudioManager instance;
    AudioManager()
    {
        instance = this;
    }
    #endregion

    public Sound[] sounds;
    public void Play(string name)
    {

        Sound s = Array.Find(sounds, Sound => Sound.Name == name);


        if (s == null)
        {
            Debug.Log("\"" + name + "\"" + " could not be found");
            return;
        }
        s.source.pitch = s.pitch;
        s.source.Play();
    }
}
