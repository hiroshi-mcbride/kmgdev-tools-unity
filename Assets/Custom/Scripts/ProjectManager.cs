using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProjectManager : MonoBehaviour
{
    private double bpm;
    private int stepCount;

    private void Awake()
    {
        ServiceLocator.Provide(Strings.ProjectManager, this);
    }

    public ProjectData GetProjectData()
    {
        bool tracksExist = ServiceLocator.TryLocate(Strings.Tracks, out List<Track> tracks);
        Assert.IsTrue(tracksExist, "Failed getting project data: tracks not initialized.");
        
        TrackData[] data = new TrackData[tracks.Count];
        for (int i = 0; i < tracks.Count; i++)
        {
            data[i] = tracks[i].GetTrackData();
        }
        
        return new ProjectData()
        {
            BPM = bpm,
            StepCount = stepCount,
            Tracks = data
        };
    }
}
