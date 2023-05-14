using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filteroff : MonoBehaviour
{
    public AsciiArtFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TurnOffFilter());
    }

    IEnumerator TurnOffFilter()
    {
        yield return new WaitForSeconds(30f);
        filter.enabled = false;
    }

}
