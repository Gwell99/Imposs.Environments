using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leavevirus : MonoBehaviour
{
    void Update()
    {
        // Check if the "K" key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Load the new scene
            SceneManager.LoadScene("MainScene");
        }
    }
}
