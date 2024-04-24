using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProjectManager : MonoBehaviour
{
    private double bpm;
    private int stepCount;
    

    public ProjectData GetProjectData()
    {
        bool tracksExist = ServiceLocator.TryLocate(Strings.Tracks, out object tracks);
        Assert.IsTrue(tracksExist);
        
        var trackList = tracks as List<Track>;
        TrackData[] data = new TrackData[trackList.Count];
        for (int i = 0; i < trackList.Count; i++)
        {
            data[i] = trackList[i].GetTrackData();
        }
        
        return new ProjectData()
        {
            BPM = bpm,
            StepCount = stepCount,
            Tracks = data
        };
    }
}
