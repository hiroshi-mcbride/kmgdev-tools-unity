using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject UIParent;
    public GameObject TrackPrefab;
    public AudioClip ClipAsset;
    
    private List<GameObject> trackObjects = new();
    private List<Track> tracks = new();

    private void Awake()
    {
        // TODO: read tracks from file oh god i still have to do all of that
        GameObject trackObject = Instantiate(TrackPrefab, UIParent.transform);
        trackObjects.Add(trackObject);
        var t = trackObject.GetComponent<Track>();
        tracks.Add(t);
        t.Initialize(
            new TrackData()
            {
                Name = "Track ",
                Clip = ClipAsset,
                Mute = false,
                Solo = false,
                Steps = new StepData[8]
                {
                    new StepData{Active = true, Index = 0},
                    new StepData{Active = true, Index = 1},
                    new StepData{Active = true, Index = 2},
                    new StepData{Active = true, Index = 3},
                    new StepData{Active = true, Index = 4},
                    new StepData{Active = true, Index = 5},
                    new StepData{Active = true, Index = 6},
                    new StepData{Active = true, Index = 7}
                }
            }
        );
        
        ServiceLocator.Provide(Strings.Tracks, tracks);
    }
    
    private void OnTrackCreated(GameObject _track)
    {
        trackObjects.Add(_track);
        tracks.Add(_track.GetComponent<Track>());
    }
    
    private void OnTrackDeleted(GameObject _track)
    {
        trackObjects.Remove(_track);
        tracks.Remove(_track.GetComponent<Track>());
    }
}
