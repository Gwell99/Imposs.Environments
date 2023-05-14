using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvaschange : MonoBehaviour
{
    public GameObject canvas;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crop"))
        {
            canvas.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log("croped");
        }
    }
}
