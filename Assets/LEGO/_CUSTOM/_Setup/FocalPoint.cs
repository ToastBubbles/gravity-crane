using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPoint : MonoBehaviour
{
    public GameObject focalP;
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = focalP.transform.position;
    }
}
