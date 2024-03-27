using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody rb;
    Vector3 com = new Vector3(0, 5, 0);

    public bool inzone = false;
    private float heldtime = 0;
    private const float minheldtime = 3f;
    private bool held = false;
    private bool framed = false;
    public bool fired = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

       // rb.centerOfMass = com;

    }


    void Update()
    {
        if (inzone && !framed)//firstframe
        {
            heldtime = Time.timeSinceLevelLoad;
            held = false;
            framed = true;
            Debug.Log("counter");
        }
        else if (!inzone)
        {
            if (!held)
            {//tapped

                
            }
        }

        if (inzone)
        {
            if (Time.timeSinceLevelLoad - heldtime > minheldtime)
            {
                held = true;
                
                fired = true;
                if (fired)
                {

                    StartCoroutine("FireFix");   
                    
                }
                    heldtime = Time.timeSinceLevelLoad;
                //fire laser
            }
        }
    }

    IEnumerator FireFix()
    {
        yield return new WaitForSeconds(0.1f);
        fired = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            Debug.Log("Entered");
            inzone = true;
            framed = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            Debug.Log("Exit");
            inzone = false;
            framed = false;
        }
    }
}
