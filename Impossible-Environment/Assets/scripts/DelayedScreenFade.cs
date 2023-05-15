using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayedScreenFade : MonoBehaviour
{
    public float delaySeconds = 3.0f;
    public float fadeTime = 1.0f;
    public Image fadeImage;

    private float timeElapsed = 0.0f;
    private bool fadeStarted = false;

    private void Start()
    {
        fadeImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (!fadeStarted && timeElapsed >= delaySeconds)
        {
            fadeImage.gameObject.SetActive(true);
            StartCoroutine(FadeScreen());
            fadeStarted = true;
        }
    }

    private IEnumerator FadeScreen()
    {
        Color startColor = fadeImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);
        float t = 0.0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, t / fadeTime);
            yield return null;
        }

        fadeImage.color = endColor;
    }
}