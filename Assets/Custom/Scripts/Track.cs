using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Track : MonoBehaviour
{
    [SerializeField] private AudioClip Clip;
    private AudioSource audioSource;

    private float bpm = 120.0f;
    private int stepCount = 8;

    private Coroutine sequence;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Clip;
    }

    public void OnPlay()
    {
        sequence = StartCoroutine(Sequence());
    }
    
    public void OnStop()
    {
        StopCoroutine(sequence);
    }

    private IEnumerator Sequence()
    {
        for (int i=0; i < stepCount; i++)
        {
            audioSource.Play();
            yield return new WaitForSeconds(60.0f / bpm);
        }
    }
}
