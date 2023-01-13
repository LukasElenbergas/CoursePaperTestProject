using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;

    void Play()
    {
        playableDirector.Play();
    }

    void OnCollisionEnter2D()
    {
        Play();
    }
}
