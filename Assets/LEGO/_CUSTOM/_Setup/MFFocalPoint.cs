using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFFocalPoint : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        transform.position = player.transform.position;
    }
}
