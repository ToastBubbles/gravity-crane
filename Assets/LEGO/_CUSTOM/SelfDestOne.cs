using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestOne : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("Destroy");
    }



    IEnumerator Destroy()
    {
        SphereCollider sc;
        sc = GetComponent<SphereCollider>();
        yield return new WaitForSeconds(0.1f);
        sc.enabled = false;
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
