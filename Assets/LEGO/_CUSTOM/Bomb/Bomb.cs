using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    Vector3 scaleChange = new Vector3(.7f, .7f, .7f);


    private float power = 100f;
    private float radius = 8f;
    private float upForce = 0.1f;
    bool runOnce = false;
    Vector3 explosionPos;

    bool started = false;
    public GameObject soundObject;

    bool explode = false;
    public LayerMask ignoreThis;
    public bool hideBomb = false;
    public bool timerStart = false;
    public bool detSoon = false;

    bool runonce2 = false;





    void Start()
    {

    }


    void FixedUpdate()
    {
        explosionPos = transform.position;


        if(transform.localScale.y < (radius * 0.5f) && started)
              transform.localScale += scaleChange;
        if(transform.localScale.y > (radius * 0.49f))
            Destroy(gameObject);


       // 

        if (!runOnce && explode)
        {
            Invoke("Started", 2);
            runOnce = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane") && runonce2 == false)
        {
            runonce2 = true;

            timerStart = true;
            StartCoroutine("Timer");
        }
    }
    void Started()
    {
        GameObject soundO;
        soundO = Instantiate(soundObject, explosionPos, transform.rotation);
        started = true;
        hideBomb = true;
        //transform.localScale = new Vector3(radius * 0.5f, radius * 0.5f, radius * 0.5f);
        Invoke("Detonate", 0.1f);
    }
    void Detonate()
    {
        
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius, ~ignoreThis);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);
            }
        }

        
        
    }

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(9f);
        //disable grab
        detSoon = true;
        yield return new WaitForSeconds(3f);// start blinking 11s to explode
        explode = true;
    }
   // void OnDrawGizmos()
   // {
   //     Gizmos.color = Color.red;
   //     Gizmos.DrawWireSphere(explosionPos, radius);
   // }

    
}
