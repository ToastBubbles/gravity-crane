using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    void Start()
    {
        var colorRend = GetComponent<Renderer>();

        colorRend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }


    void Update()
    {
        
    }
}
