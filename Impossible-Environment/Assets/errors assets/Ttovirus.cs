using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ttovirus: MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        Debug.Log("Hello1");
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "cube")
        {
            Debug.Log("Hello2");
            SceneManager.LoadSceneAsync("VirusScene");
        }
    }
}
