using UnityEngine;
using UnityEngine.SceneManagement;

public class textsExit : MonoBehaviour
{
    public KeyCode keyToPress = KeyCode.KeypadEnter;
    public string sceneToLoad = "TextsToMain";

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}