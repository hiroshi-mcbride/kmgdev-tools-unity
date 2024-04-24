using System;

[Serializable]
public struct ProjectData
{
    public double BPM;
    public int StepCount;
    public TrackData[] Tracks;
}