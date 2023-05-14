using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressK : MonoBehaviour
{
    //public string MainScene;

    // Update is called once per frame
    void Update()
    {
        // Check if the "K" key is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Load the new scene
            SceneManager.LoadScene("MainScene");
        }
    }
}
