using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSaw : MonoBehaviour
{
    public int speed = 10;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
