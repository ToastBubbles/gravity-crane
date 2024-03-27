using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    //grabbable tags are "Grabbable" "Player" "projectile"
    public float forceFactor = 200;
    public float maxrb = 5;
    public bool canGrabmore = true;
    public bool maxCap = false;
    public AudioClip clip1;
    public AudioClip clip2;
    private AudioSource aS1;
    private bool holdingPlayer = false;

    public bool combo = false;
    

    List<Rigidbody> rbMag = new List<Rigidbody>();
    Transform magPoint;
    void Start()
    {
        magPoint = GetComponent<Transform>();
        aS1 = GetComponent<AudioSource>();

    }


    void FixedUpdate()
    {
        foreach(Rigidbody rbItem in rbMag)
        {
            if(rbItem != null)
                rbItem.AddForce((magPoint.position - rbItem.position) * forceFactor * Time.deltaTime);
        }
        rbMag.RemoveAll(rbItem => rbItem == null);

        if(maxrb == rbMag.Count)
        {
            maxCap = true;
        }
        else
        {
            maxCap = false;
        }

        if (maxCap || !canGrabmore)
            combo = true;
        else
            combo = false;

        if (rbMag.Count > 0)
        {
            
            if(rbMag[0].name == "bomb")
            {
                Debug.Log(rbMag[0].name);
                if (!rbMag[0].CompareTag("GrabbableLarge"))
                {
                    rbMag.Remove(rbMag[0]);
                    canGrabmore = true;
                }
            }
        }
            

    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.CompareTag("Grabbable") || other.CompareTag("Projectile")) && rbMag.Count < maxrb && canGrabmore == true && (!other.CompareTag("Player") || !other.CompareTag("GrabbableLarge")))
        {
            aS1.PlayOneShot(clip1);
            rbMag.Add(other.GetComponent<Rigidbody>());
        } else if (other.CompareTag("GrabbableLarge") && !holdingPlayer)// && !other.CompareTag("Player"))
        {
            aS1.PlayOneShot(clip2);
            rbMag.Clear();
            rbMag.Add(other.GetComponent<Rigidbody>());
            canGrabmore = false;
        }else if (other.CompareTag("Player"))
        {
            holdingPlayer = true;
            aS1.PlayOneShot(clip2);
            rbMag.Clear();
            rbMag.Add(other.GetComponent<Rigidbody>());
            canGrabmore = false;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("ClearGrab") && !holdingPlayer)
        {
            rbMag.Clear();
        }
        if (other.CompareTag("ClearAllGrab"))
        {
            rbMag.Clear();
        }
        if (other.CompareTag("Player"))
        {
            holdingPlayer = true;
            canGrabmore = false;
        }
        if (other.CompareTag("GrabbableLarge"))
        {
            canGrabmore = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabbable") || other.CompareTag("Projectile") || other.CompareTag("Player") || other.CompareTag("GrabbableLarge"))
        {
            rbMag.Remove(other.GetComponent<Rigidbody>());
        }
        if (other.CompareTag("Player") || other.CompareTag("GrabbableLarge"))
        {
            holdingPlayer = false;
            rbMag.Remove(other.GetComponent<Rigidbody>());
            canGrabmore = true;
        }
    }




}
