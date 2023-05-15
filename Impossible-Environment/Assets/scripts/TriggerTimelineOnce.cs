using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimelineOnce : MonoBehaviour
{
    public PlayableDirector timelineToPlay;
    public GameObject uiText;
    public float uiTextDelay = 5f; // Delay time in seconds

    private bool hasPlayed = false;

    private void Start()
    {
        // Deactivate the UI text GameObject
        uiText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Enable the PlayableDirector component to play the timeline
            timelineToPlay.enabled = true;

            // Play the timeline
            timelineToPlay.Play();

            // Set hasPlayed to true to prevent the timeline from playing again
            hasPlayed = true;

            // Activate the UI text after the specified delay time
            Invoke("ActivateUIText", uiTextDelay);

            // Disable the collider to prevent the player from triggering the timeline again
            GetComponent<Collider>().enabled = false;

            // Disable the script to prevent it from re-enabling the collider
            enabled = false;
        }
    }

    private void ActivateUIText()
    {
        uiText.SetActive(true);
    }
}