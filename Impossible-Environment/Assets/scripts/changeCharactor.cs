using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCharactor : MonoBehaviour
{
    public GameObject charactor;
    public GameObject crop;
    public GameObject brush;
    public GameObject eraser;
    public GameObject paint;
    public GameObject magnifier;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            crop.SetActive(true);
            charactor.SetActive(false);
            brush.SetActive(false);
            eraser.SetActive(false);
            paint.SetActive(false);
            magnifier.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            brush.SetActive(true);
            charactor.SetActive(false);
            crop.SetActive(false);
            eraser.SetActive(false);
            paint.SetActive(false);
            magnifier.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            eraser.SetActive(true);
            charactor.SetActive(false);
            brush.SetActive(false);
            crop.SetActive(false);
            paint.SetActive(false);
            magnifier.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            paint.SetActive(true);
            charactor.SetActive(false);
            brush.SetActive(false);
            crop.SetActive(false);
            eraser.SetActive(false);
            magnifier.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            magnifier.SetActive(true);
            charactor.SetActive(false);
            brush.SetActive(false);
            crop.SetActive(false);
            eraser.SetActive(false);
            paint.SetActive(false);
        }

    }
}
