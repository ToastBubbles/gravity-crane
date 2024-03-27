using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CamControl : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;
    //private bool minifigDestroyed = false;
    private GameObject player;
    private bool won = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //minifigDestroyed = player.GetComponent<Unity.LEGO.Behaviors>().defeated;
        
    }

 
    void Update()
    {
        won = player.GetComponent<PlayerControl>().win;
        if (!player.GetComponent<Animator>().enabled)
            SwitchCam();
        if (won)
            SwitchCam();
    }

    void SwitchCam()
    {
        vcam1.Priority = 0;
        vcam2.Priority = 1;
    }
}
