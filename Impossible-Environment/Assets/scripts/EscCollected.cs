using UnityEngine;
using UnityEngine.SceneManagement;

public class EscCollected : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load
    public string[] requiredScenes; // An array of the names of the required scenes

    private int sceneCount = 0; // The number of required scenes the player has entered
    private bool[] enteredScenes; // A boolean array to keep track of which required scenes the player has entered

    private void Start()
    {
        enteredScenes = new bool[requiredScenes.Length]; // Initialize the enteredScenes array with the same length as the requiredScenes array
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object that entered the trigger is the player
        {
            string currentScene = SceneManager.GetActiveScene().name; // Get the name of the current scene

            for (int i = 0; i < requiredScenes.Length; i++)
            {
                if (currentScene == requiredScenes[i] && !enteredScenes[i]) // Check if the current scene is a required scene that the player has not yet entered
                {
                    enteredScenes[i] = true; // Mark the required scene as entered
                    sceneCount++; // Increment the scene count
                }
            }

            if (sceneCount >= 3) // Check if the player has entered all required scenes
            {
                SceneManager.LoadScene(sceneToLoad); // Load the specified scene
            }
        }
    }
}