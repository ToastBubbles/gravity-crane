using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTex : MonoBehaviour
{
    private float scrollSpeedX = -5f;
    public Material mat;
    private LineRenderer lr;
    public GameObject burst;
    private bool cooldown = true;
    private bool fire = false;
    public GameObject parentlaser;

    public bool turretMode = true;

    private float ti = 0f;
    private float duration = 0.5f;
    private bool chargeRes = false;

    private bool turretCooldown = true;
    public LayerMask lm1;

    private AudioSource aS;

    private Color t;
    private Color o;

    private Color l;
    

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>();
        o = new Color(mat.color.r, mat.color.g * 10, mat.color.b, 255f);
        t = new Color(mat.color.r, mat.color.g, mat.color.b, 0f);
        mat.SetColor("_Color", t);
    }

    void Update()
    {
       

        fire = parentlaser.GetComponent<Laser>().fired;
       float offsetX = scrollSpeedX * Time.time;
       mat.SetTextureOffset("_MainTex", new Vector2(offsetX, 0));//move texture
       

        lr.SetPosition(0, transform.position);//set point 0

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, ~lm1))
        {
            lr.SetPosition(1, hit.point);//set point1

            


            //instantiate hit explosion/Point
        }
        if (cooldown && fire && !turretMode)
        {
            Debug.Log("FIRE!");
            aS.Play(0);
            GameObject blast;
            blast = Instantiate(burst, hit.point, transform.rotation);
           
            StartCoroutine("Beam");
            StartCoroutine("TimeDelay");


        }
        if(turretMode && turretCooldown)
        {
            aS.Play(0);
            GameObject blast;
            blast = Instantiate(burst, hit.point, transform.rotation);

            StartCoroutine("Beam");
            StartCoroutine("LongTimeDelay");
        }
   
            ColorRange();



    }

    void ColorRange()
    {
        if (chargeRes)
        {
            float im = 1.1f * ti;
            //Debug.Log("Lerping");
            mat.SetColor("_Color", l * im);
            l = Color.Lerp(t, o, ti);


            if (ti < 1)
            {
                ti += Time.deltaTime / duration;
            }
        }
        else
        {
            ti = 0;
            mat.SetColor("_Color", t);
        }
    }
    IEnumerator Beam()
    {

        chargeRes = true;

        //mat.SetColor("_Color", o);
        
        yield return new WaitForSeconds(0.5f);
        chargeRes = false;
        //mat.SetColor("_Color", t);
    }

    

    IEnumerator TimeDelay() {
        cooldown = false;
        yield return new WaitForSeconds(1);
        cooldown = true;
    }
    IEnumerator LongTimeDelay()
    {
        turretCooldown = false;
        yield return new WaitForSeconds(4);
        turretCooldown = true;
    }

}
