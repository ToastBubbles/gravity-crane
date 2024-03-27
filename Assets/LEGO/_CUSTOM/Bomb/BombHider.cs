using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHider : MonoBehaviour
{
    public GameObject[] parts = new GameObject[5];
    public GameObject explosion;

    bool start = false;
    bool timeStart = false;
    void Start()
    {
        
    }


    void Update()
    {
        if (explosion)
        {
            start = explosion.GetComponent<Bomb>().hideBomb;
            timeStart = explosion.GetComponent<Bomb>().detSoon;
        }

        if (start)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }

        if(timeStart)
             transform.gameObject.tag = "Untagged";

    }
}
