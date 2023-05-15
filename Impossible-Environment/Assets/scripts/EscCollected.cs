using UnityEngine;
using UnityEngine.SceneManagement;

public class EscCollected : MonoBehaviour
{
    public string[] targetScenes; // the names of the scenes to detect
    public string sceneToLoad; // the name of the scene to load when all target scenes have been entered
    public GameObject uiText; // the UI text to activate when all target scenes have been entered
    public GameObject uiButton; // the UI button to activate when all target scenes have been entered
    public float delayTime = 2f; // the delay time in seconds before the UI elements appear

    private int sceneCount = 0; // the number of target scenes entered so far

    private void OnTriggerEnter(Collider other)
    {
        // check if the other collider is the player and if the scene is one of the target scenes
        if (other.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            for (int i = 0; i < targetScenes.Length; i++)
            {
                if (currentScene == targetScenes[i])
                {
                    sceneCount++;
                    break;
                }
            }

            // if all target scenes have been entered, activate the UI elements and load the next scene
            if (sceneCount == targetScenes.Length)
            {
                // activate the UI elements after the specified delay time
                Invoke("ActivateUI", delayTime);
            }
        }
    }

    private void ActivateUI()
    {
        uiText.SetActive(true);
        uiButton.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}