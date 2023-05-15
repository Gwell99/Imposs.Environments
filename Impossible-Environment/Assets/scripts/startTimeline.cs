using UnityEngine;
using UnityEngine.Playables;

public class startTimeline : MonoBehaviour
{
    public PlayableDirector timelineToPlay;

    private void Start()
    {
        // Play the timeline immediately
        timelineToPlay.Play();
    }
}