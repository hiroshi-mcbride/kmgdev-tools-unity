using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackManager : MonoBehaviour
{
    private Coroutine sequence;
    private double bpm = 120.0f;
    
    public int StepCount
    {
        get => stepCount;
        set
        {
            if (stepCount != value)
            {
                // event manager invoke step count changed
            }

            stepCount = value;
        }
    }
    private int stepCount = 8;
    
    

    public void OnPlay()
    {
        if (ServiceLocator.TryLocate(Strings.Tracks, out object tracks))
        {
            var trackList = (List<Track>)tracks;
            foreach (Track t in trackList)
            {
                t.Play(bpm);
            }
        }
    }
    
    public void OnStop()
    {
        
    }

    // private IEnumerator Sequence()
    // {
    //     bool trackHasSolo = false;
    //     for (int i=0; i < stepCount; i++)
    //     {
    //         foreach (Track t in tracks)
    //         {
    //             if (t.Mute) continue;
    //             if (t.Solo) trackHasSolo = true;
    //             if (trackHasSolo && !t.Solo) continue;
    //             
    //             if (t.stepsActive[i])
    //             {
    //                 //t.Play();
    //             }
    //         }
    //         yield return new WaitForSeconds(60.0f / bpm);
    //     }
    // }
}
