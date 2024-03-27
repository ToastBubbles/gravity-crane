using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Ground Check
    public Animator anim;
    public LayerMask layerMask;
    public bool win = false;

    private bool inCrane = false;
 
    void Start()
    {
        
        //Physics.IgnoreLayerCollision(9, 14);
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("Grounded", false);
      ////////////////
      ///
      /// 
      /// 
      /// 
      /// 
      /// 
      /// 
      /// 
      /// 
      /// 
      ///Debug.Log(anim.GetBool("Grounded"));
        Vector3 t = new Vector3(transform.position.x,transform.position.y+1f,transform.position.z);
        bool grounded = (Physics.Raycast(t, Vector3.down, 1f, ~layerMask));
        if (!inCrane)
            anim.SetBool("Grounded", grounded);
        else
            anim.SetBool("Grounded", false);

        if (win == true)
            Win();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WinZone"))
        {
            anim.SetBool("Play Special", true);

            win = true;
            //transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            inCrane = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            inCrane = false;
        }
    }

    private void Win()
    {
        //transform.eulerAngles = new Vector3(0, -90, 0);
        //Quaternion from = transform.rotation;
        Quaternion to = Quaternion.Euler(0, -90, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, to, Time.time * 0.006f);

        transform.Translate(Vector3.left * 10 * Time.deltaTime, Space.World);
    }

}
