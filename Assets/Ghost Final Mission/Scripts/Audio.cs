using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public Sound[] Musics;
    public Sound[] Sounds;
    public static bool PlaySFX = true;
    public float fadeSpeed = 0.03f;

    void Awake()
    {
        // Create new audio source for each music
        foreach (Sound sound in Musics)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.outputAudioMixerGroup = sound.Mixer;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
        // Create new audio source for each sounds
        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.outputAudioMixerGroup = sound.Mixer;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
        instance = this;
    }

    private void Start()
    {
        // PlayRandomMusic();
    }

    public void PlayRandomMusic()
    {
        int randomIndex = UnityEngine.Random.Range(0, Musics.Length);
        PlayMusic(randomIndex);
    }

    public void PlayMusic(int musicIndex)
    {
        int index = 0;
        foreach (Sound sound in Musics)
        {
            if (index == musicIndex)
            {
                sound.Source.Play();
                // FindObjectOfType<PlatformController>()?.SetAudioSource(sound.Source);
            }
            else
            {
                sound.Source.Stop();
            }
            index++;
        }
    }

    public void Play(string name)
    {
        if (name == "")
            return;

        Sound sound = Array.Find(Sounds, s => s.Name == name);
        if (sound != null)
        {
            sound.Source.Play();
        }
        else
        {
            print("Sound not found");
        }
    }

    public IEnumerator FadeOut(string name)
    {
        print("FadeOut");
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        while (s.Source.volume > 0f)
        {
            s.Source.volume -= fadeSpeed * 1;
            yield return new WaitForSeconds(0.001f);
        }
        print("Pause");
        s.Source.Pause();
        s.Source.volume = s.Volume;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        s.Source.Pause();
    }

    public void Unpause(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        s.Source.UnPause();
    }
}
