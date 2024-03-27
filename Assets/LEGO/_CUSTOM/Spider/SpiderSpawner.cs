using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{

    List<Rigidbody> spiders = new List<Rigidbody>();
    int maxSpiders = 4;
    public Rigidbody spider1;
    public Rigidbody spider2;
    public Transform spiderSpot;
    void Start()
    {
        StartCoroutine("Spawn");
    }


    void Update()
    {
       // spiders.RemoveAll(rbItem => rbItem == null);
    }

    IEnumerator Spawn()
    {
        int randspawn = Random.Range(0, 2);
        yield return new WaitForSeconds(5);
        Rigidbody clone;
        if (spiders.Count < maxSpiders)
        {
            if (randspawn == 0)
            {
                clone = Instantiate(spider1, spiderSpot.position, spiderSpot.rotation);
                spiders.Add(clone);
            }
            if (randspawn == 1)
            {
                clone = Instantiate(spider2, spiderSpot.position, spiderSpot.rotation);
                spiders.Add(clone);
            }
        }
        

        StartCoroutine("Spawn");
    }
}
