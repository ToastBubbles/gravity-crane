using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{

    private float speed = 2;
    private int rand = 0;
    Rigidbody rb;
    public GameObject player;
    public LayerMask IgnoreMe;
    public bool seePlayer = false;
    private bool dead = false;
    public GameObject smokePuff;
    private bool grounded = false;
    bool groundCheckLimiter = false;
    
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Control");
        StartCoroutine("RandJump");
        
    }

    
    void Update()
    {
        if(!grounded && !groundCheckLimiter)
        {
            groundCheckLimiter = true;
            StartCoroutine("UpsideDownCheck");
        }
        GroundCheck();
        if (!dead)
        {
            ViewChecker();

            if (seePlayer)
            {

               // speed = 3;
                if (player.transform.position.x > transform.position.x)
                    TurnLeft();
                if (player.transform.position.x < transform.position.x)
                    TurnRight();
                Crawl();
            }
            else
            {
                //speed = 2;
                if (rand == 0)
                    TurnLeft();
                if (rand == 1)
                    TurnRight();
                if (rand == 2 || rand == 3)
                    Crawl();
            }
        }
        

    }

    void GroundCheck()
    {
        Vector3 vFix2 = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
       // grounded = (Physics.Raycast(vFix2, Vector3.down, 0.5f, ~IgnoreMe));
        Debug.Log(grounded);

        RaycastHit hit;

       
        if (Physics.Raycast(vFix2, Vector3.down, out hit, 0.6f, ~IgnoreMe))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        Debug.DrawRay(vFix2, Vector3.down,  Color.red);

    }

    void ViewChecker()
    {
        Vector3 vFix = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        float maxRange = 15;
        RaycastHit hit;

        if (Vector3.Distance(transform.position, player.transform.position) < maxRange)
        {
            if (Physics.Raycast(transform.position, (vFix - transform.position), out hit, maxRange, ~IgnoreMe))
            {
                if (hit.transform == player.transform)
                {
                    //Debug.Log("I SEE YOU!");
                    seePlayer = true;
                    // In Range and i can see you!
                }
                else
                {
                    seePlayer = false;
                }
                //Debug.DrawRay(transform.position, (vFix - transform.position), Color.red);
            }
        }
    }
    void TurnLeft()
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x,  90f, transform.rotation.z), Time.deltaTime * speed);
    }

    void TurnRight()
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, -90f, transform.rotation.z), Time.deltaTime * speed);
    }
    void UpsidedownFix()
    {
        if(!grounded)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(180, transform.rotation.y, transform.rotation.z), Time.deltaTime * speed);
    }

    void Crawl()
    { 
        if(grounded)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
      //rb.MovePosition(transform.position + transform.forward * 12 * speed * Time.deltaTime);

    }
    void Dead()
    {
        transform.gameObject.tag = "Untagged";
        Vector3 up = new Vector3(0, 50, 0);
        rb.AddForce(up, ForceMode.Impulse);
    }

    void Jump()
    {
        Vector3 up = new Vector3(0, 5, 0);
        rb.AddForce(up, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            if (!dead)
            {
                StartCoroutine("Deadtime");
                dead = true;
            }
            
            
        }
    }
    IEnumerator Deadtime()
    {
        Dead();
        yield return new WaitForSeconds(3);
        GameObject puff;
        puff = Instantiate(smokePuff, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
    IEnumerator Control()
    {
        
        float randTime = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(randTime);
        rand = Random.Range(0, 4);
        //Debug.Log(rand);
        StartCoroutine("Control");
    }
    IEnumerator RandJump()
    {
        float randTime = Random.Range(2.0f, 10.0f);
        yield return new WaitForSeconds(randTime);
        if (!dead && grounded && !seePlayer)
        {
            Jump();

            StartCoroutine("RandJump");
        }
        
    }
    IEnumerator UpsideDownCheck()
    {

        yield return new WaitForSeconds(3);
        groundCheckLimiter = false;
        if (!grounded)
            UpsidedownFix();
    }
}
