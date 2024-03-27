using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSlide : MonoBehaviour
{
    public float startingPos = -21.6f; //-21.6f is base
    public int dirFlip = 1;
    public float distance = 43.2f;
    public float speed = 3f;
    void Start()
    {

    }

    
    void Update()
    {
        transform.position = new Vector3((Mathf.PingPong(Time.time * speed, distance) + startingPos) * dirFlip, transform.position.y, transform.position.z);

    }
}
