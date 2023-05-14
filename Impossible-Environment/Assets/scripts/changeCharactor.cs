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

    public GameObject cube;
    public Renderer cubeRenderer;
    public Material matOfObject;
    [SerializeField] private Color newColor;
    [SerializeField] private Color[] colors;
    public KeyCode colorChange;

    public GameObject exit;

    public GameObject canvas;
    public GameObject layer1;
    public Renderer canvasRenderer1;
    public GameObject layer2;
    public GameObject layer3;
    public GameObject layer4;
    public Renderer canvasRenderer2;

    bool layerDes = false;
    bool Cselected = false;
    bool Eselected = false;
    bool Gselected = false;
    bool Zselected = false;


    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
   
    }

    void Update()
    {
        if (Input.GetKeyDown(colorChange))
        {
            cubeRenderer.material.color = colors[Random.Range(0, 6)];
            newColor = cubeRenderer.material.color;
        
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            crop.SetActive(true);
            charactor.SetActive(false);
            brush.SetActive(false);
            eraser.SetActive(false);
            paint.SetActive(false);
            magnifier.SetActive(false);
            Cselected = true;
            Eselected = false;
            Gselected = false;
            Zselected = false;
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
            Eselected = true;
            Cselected = false;
            Gselected = false;
            Zselected = false;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            paint.SetActive(true);
            charactor.SetActive(false);
            brush.SetActive(false);
            crop.SetActive(false);
            eraser.SetActive(false);
            magnifier.SetActive(false);
            Gselected = true;
            Eselected = false;
            Cselected = false;
            Zselected = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            magnifier.SetActive(true);
            charactor.SetActive(false);
            brush.SetActive(false);
            crop.SetActive(false);
            eraser.SetActive(false);
            paint.SetActive(false);
            Zselected = true;
            Gselected = false;
            Eselected = false;
            Cselected = false;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& Cselected)
        {
            canvas.transform.localScale = new Vector3(1, 2, 1);
        }
        else if (other.CompareTag("Player") && Eselected)
        {
            exit.SetActive(true);
            Destroy(layer1);
            Destroy(layer2,3);
            Destroy(layer3,5);
            layerDes = true;
        }
        else if(other.CompareTag("Player") && Gselected)
        {
            if (layerDes == false) { 
            canvasRenderer1 = layer1.GetComponent<Renderer>();
            canvasRenderer1.material.color = newColor;
                canvasRenderer2 = layer4.GetComponent<Renderer>();
                canvasRenderer2.material.color = newColor;
            }
            if (layerDes) { 
            canvasRenderer2 = layer4.GetComponent<Renderer>();  
            canvasRenderer2.material.color = newColor;}
        }
        else if (other.CompareTag("Player") && Zselected)
        {
            canvas.transform.localScale = new Vector3(3, 3, 3);
        }
    }
}
