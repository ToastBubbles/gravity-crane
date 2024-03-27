using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
   
    void Start()
    {
        RandomRot();
    }

   void RandomRot()
    {
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            /* transform.localRotation = new Quaternion(transform.localRotation.x,
                                             50,
                                             transform.localRotation.z,
                                             transform.localRotation.w);// * -1.0f);*/
            // transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.localRotation.y + 180, transform.rotation.z);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 180, transform.localEulerAngles.z);
        }
    }
    void Update()
    {
        
    }
}
