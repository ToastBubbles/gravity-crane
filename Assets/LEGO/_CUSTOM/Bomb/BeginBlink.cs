using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBlink : MonoBehaviour
{
    private Animator anim;
    public GameObject explosion;
    private bool begin = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(explosion)
            begin = explosion.GetComponent<Bomb>().timerStart;


        if (begin)
            anim.SetBool("Detonate", true);
    }
}
