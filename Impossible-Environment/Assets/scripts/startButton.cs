using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startButton : MonoBehaviour
{
    public string sceneToLoad;

    private Button button;

    private void Start()
    {
        // Get the button component
        button = GetComponent<Button>();

        // Add a listener to the button's click event
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}