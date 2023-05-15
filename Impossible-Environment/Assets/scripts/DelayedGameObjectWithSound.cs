using UnityEngine;

public class DelayedGameObjectWithSound : MonoBehaviour
{
    public float delaySeconds = 3.0f;
    public GameObject gameObjectToShow;
    public AudioClip soundEffect;

    private float timeElapsed = 0.0f;
    private bool gameObjectShown = false;

    private void Start()
    {
        gameObjectToShow.SetActive(false);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (!gameObjectShown && timeElapsed >= delaySeconds)
        {
            gameObjectToShow.SetActive(true);
            gameObjectShown = true;

            if (soundEffect != null)
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }
        }
    }
}