using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class changeColor : MonoBehaviour
{
    public GameObject cube;
    public Renderer cubeRenderer;
    public Material matOfObject;
    [SerializeField] private Color newColor;
    [SerializeField] private Color[]colors;
    public KeyCode colorChange;
    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(colorChange))
        {
            cubeRenderer.material.color = colors[Random.Range(0, 6)];
        }
    }
    }


 
