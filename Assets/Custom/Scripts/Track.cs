using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class Track : MonoBehaviour
{
    [SerializeField] private AudioClip Clip;
    private AudioSource audioSource;

    private int stepCount = 8;

    public bool Mute, Solo;
    public Dictionary<int, bool> stepsActive = new();
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Clip;
        
        stepsActive = new Dictionary<int, bool>();
        for (int i=0; i < stepCount; i++)
        {
            stepsActive.Add(i, false);
        }

        stepsActive[0] = true;
        stepsActive[2] = true;
        stepsActive[5] = true;
        stepsActive[7] = true;
    }

    public void Play()
    {
        audioSource.Play();
    }
}
