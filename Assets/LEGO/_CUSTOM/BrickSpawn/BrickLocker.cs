using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLocker : MonoBehaviour
{
    Rigidbody rb;
    bool runOnce = true;

    bool maxCap = false;
    private GameObject grabZone;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;//PositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //Physics.IgnoreLayerCollision(16, 16);
        //Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<Collider>());
        grabZone = GameObject.FindGameObjectWithTag("Crane");
    }


    void Update()
    {
        maxCap = grabZone.GetComponent<Grab>().combo;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane") && !maxCap || other.CompareTag("Bomb"))
        {
            if (runOnce)
                Constraint();
                
        }


    }

    void Constraint()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        runOnce = false;
    }
}
