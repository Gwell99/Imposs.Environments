using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiElement; // the UI element to show

    void Start()
    {
        uiElement.SetActive(false); // hide the UI element by default
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hi");
            uiElement.SetActive(true); // show the UI element when the player collides with the object
        }
    }

}
