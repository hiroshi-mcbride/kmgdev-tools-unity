using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class Track : MonoBehaviour
{
    [SerializeField] private GameObject StepButtonPrefab;
    public bool Mute, Solo;
    public Dictionary<int, StepButton> stepButtons = new();
    private AudioSource audioSource;
    private int stepCount;
    private int currentStep;
    private bool isPlaying;
    private double interval;
    private double nextEventTime;
    
    public void Play(double _bpm)
    {
        if (Mute) return;
        if (!stepButtons.Any(_x => _x.Value.Active)) return;
        interval = 60.0f / _bpm;
        currentStep = 0;
        stepCount = stepButtons.Count;
        nextEventTime = AudioSettings.dspTime;
        isPlaying = true;
    }
    
    public void Stop()
    {
        audioSource.Stop();
    }

    public void Initialize(TrackData _trackData)
    {
        Mute = _trackData.Mute;
        Solo = _trackData.Solo;
        audioSource.clip = _trackData.Clip;
        StepData[] steps = _trackData.Steps;
        
        foreach (StepData step in steps)
        {
            GameObject button = Instantiate(StepButtonPrefab, transform);
            var sb = button.GetComponent<StepButton>();
            sb.Index = step.Index;
            sb.Active = step.Active;
            stepButtons.Add(step.Index, sb);
        }
        stepButtons = stepButtons.OrderBy(_x => _x.Key).ToDictionary(_x => _x.Key, _x => _x.Value);
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPlaying)
        {
            double time = AudioSettings.dspTime;

            if (currentStep >= stepCount)
            {
                currentStep = 0;
                isPlaying = false;
            }
            
            if (time > nextEventTime)
            {
                bool active = stepButtons[currentStep].Active;
                nextEventTime += interval;

                if (active)
                {
                    audioSource.Play();
                }
                currentStep++;
            }
            
        }
        
    }
}
