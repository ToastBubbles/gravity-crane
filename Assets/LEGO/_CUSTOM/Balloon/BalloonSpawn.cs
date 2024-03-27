using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour
{
    public Rigidbody balloon;
    public Transform balloonSpot;
    AudioSource audioS;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        StartCoroutine("Spawn");
    }

    
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        float randTime = Random.Range(2.1f, 4.2f);
        yield return new WaitForSeconds(randTime);
        Rigidbody clone;
        clone = Instantiate(balloon, balloonSpot.position, balloonSpot.rotation);
        audioS.Play(0);
        StartCoroutine("Spawn");
    }
}
