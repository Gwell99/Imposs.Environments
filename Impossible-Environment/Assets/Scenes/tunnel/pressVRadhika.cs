using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressVRadhika : MonoBehaviour
{
    void Update()
    {
        // Check if the "K" key is pressed
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Load the new scene
            SceneManager.LoadScene("VirusScene");
        }
    }
}
