using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackManager : MonoBehaviour
{
    public List<Track> tracks = new();
    private Coroutine sequence;
    private float bpm = 120.0f;
    
    private int stepCount = 8;
    
    private void OnTrackCreated(Track _track)
    {
        tracks.Add(_track);
    }
    
    private void OnTrackDeleted(Track _track)
    {
        tracks.Remove(_track);
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
        bool trackHasSolo = false;
        for (int i=0; i < stepCount; i++)
        {
            foreach (Track t in tracks)
            {
                if (t.Mute) continue;
                if (t.Solo) trackHasSolo = true;
                if (trackHasSolo && !t.Solo) continue;
                
                if (t.stepsActive[i])
                {
                    t.Play();
                }
            }
            yield return new WaitForSeconds(60.0f / bpm);
        }
    }
}
