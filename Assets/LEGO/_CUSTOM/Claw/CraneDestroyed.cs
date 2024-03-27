using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraneDestroyed : MonoBehaviour
{
    
    public GameObject[] children = new GameObject[6];
    public GameObject arrow;
    public GameObject grabField;

    private AudioSource aS;

    public bool failed = false;
    private bool runOnce = false;
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }


    void Update()
    {
        //GameOverEvent evt = Events.GameOverEvent;
        //EventManager.Broadcast(Event.);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard") && failed == false || other.CompareTag("Bomb") && failed == false)
        {
            if (!runOnce)
            {
                BreakModel();
                failed = true;
                runOnce = true;
            }

        }
    }
    void BreakModel()
    {
        arrow.SetActive(false);
        grabField.SetActive(false);
        aS.Play(0);
        for (int i = 0; i < children.Length; i++)
        {
            children[i].AddComponent<Rigidbody>();

        }
    }
}
