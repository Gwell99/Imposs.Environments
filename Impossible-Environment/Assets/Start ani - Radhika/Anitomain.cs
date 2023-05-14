using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anitomain : MonoBehaviour
{
    public string MainScene;

    private void Start()
    {
        Debug.Log("Hello1");
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Cube")
        {
            Debug.Log("Hello2");
            SceneManager.LoadSceneAsync("MainScene");
        }
    }
}
