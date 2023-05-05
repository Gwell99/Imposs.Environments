using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class changeColor : MonoBehaviour
{
    public Material matOfObject;
    public Color newColor;
    public KeyCode colorChange;
    void Start()
    {
        matOfObject.color = Color.black;
    }


    void Update()
    {
        if(Input.GetKeyDown(colorChange))
        {
            if (matOfObject.color == Color.black)
            {
                matOfObject.color = newColor;
            }
            else
            {
                matOfObject.color = Color.black;
            }
        }
    }
}