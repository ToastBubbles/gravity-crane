using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSound : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("Destroy");
    }

   
    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4.1f);
        Destroy(gameObject);
    }
}
