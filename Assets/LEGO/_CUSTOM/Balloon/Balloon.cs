using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float floatForce = 3.5f;
    public Vector3 Scale;
    public float scalingRate;
    private bool floating = false;
    public GameObject soundObj;
    private Color tColor;
    private Light lt;
    bool nightMode = false;


    void Start()
    { 
        StartCoroutine("PopDelay");
        tColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        var colorRend = GetComponent<Renderer>();

        colorRend.material.color = tColor;

        if(gameObject.GetComponent<Light>() != null)
        {
            nightMode = true;
            lt = gameObject.GetComponent<Light>();
            lt.color = tColor;
        }


        
    }


    void FixedUpdate()
    {
        if(floating)
            GetComponent<Rigidbody>().AddForce(Vector3.up * floatForce);
    }
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Scale, scalingRate * Time.deltaTime);
        if (transform.localScale.x > 560)
            floating = true;
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Pop();
        }
    }

    IEnumerator PopDelay()
    {
        yield return new WaitForSeconds(12);
        Pop();

    }

    void Pop()
    {
        ParticleSystem ps;
        GameObject clone;
        clone = Instantiate(soundObj, transform.position, transform.rotation);
        ps = clone.GetComponent<ParticleSystem>();
        //ps.main.startColor = Color.red;
        ParticleSystem.MainModule pm = ps.main;
        pm.startColor = tColor;


        Destroy(gameObject);
    }
}
