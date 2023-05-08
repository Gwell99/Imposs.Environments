using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting : MonoBehaviour
{
    private string input;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        
    }

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
}
