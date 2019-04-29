using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public float startDelay;

    public int currentBpm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(this.gameObject);


        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        currentBpm = s.bpm;

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found. :~(");
            return;
        }

        s.source.Play();
    }

    void Start()
    {
        List<Sound> _songs = new List<Sound>();

        foreach(Sound s in sounds)
        {
            if (s.isSong)
            {
                _songs.Add(s);
            }
        }

        System.Random rnd = new System.Random();
        int diceRoll = rnd.Next(0, _songs.Count);

        StartCoroutine(playSong(startDelay, _songs[diceRoll].name));
    }

    IEnumerator playSong(float delay, string name)
    {
        yield return new WaitForSeconds(delay);
        Play(name);
    }

    void Update()
    {
        
    }
}
