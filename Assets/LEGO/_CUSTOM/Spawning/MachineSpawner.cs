using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MachineSpawner : MonoBehaviour
{

    public bool spider;
    public bool balloon;

    public GameObject spiderDen;
    public GameObject balloonSpawner;
    void Start()
    {
        GameObject spawnedMach;
        if (spider)
            spawnedMach = Instantiate(spiderDen, transform.position, transform.rotation);
        if (balloon)
            spawnedMach = Instantiate(balloonSpawner, transform.position, transform.rotation);
    }

 
    void Update()
    {
        
    }
}
