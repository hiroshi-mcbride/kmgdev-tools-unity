using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TrackData
{
    public string Name;
    public AudioClip Clip;
    public bool Mute, Solo;
    public float Gain;
    public float Panning;
    public StepData[] Steps;
}
