using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClipping : MonoBehaviour
{
    public bool isClipping;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            isClipping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            isClipping = false;
        }
    }
}
