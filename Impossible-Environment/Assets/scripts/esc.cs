using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class esc : MonoBehaviour
{
    public List<string> requiredScenes;
    public string originalSceneName;
    public Text uiText;
    public Button uiButton;

    private bool allScenesEntered = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        uiText.gameObject.SetActive(false);
        uiButton.gameObject.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (requiredScenes.Contains(scene.name))
        {
            requiredScenes.Remove(scene.name);
            if (requiredScenes.Count == 0)
            {
                allScenesEntered = true;
            }
        }
        else if (scene.name == originalSceneName)
        {
            if (allScenesEntered)
            {
                uiText.gameObject.SetActive(true);
                uiButton.gameObject.SetActive(true);
            }
        }
    }
}