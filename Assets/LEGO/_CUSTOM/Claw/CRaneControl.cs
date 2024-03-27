using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRaneControl : MonoBehaviour
{
    int dir = -1; //direction of travel (-1 = up, 1 = down)
    int sdir = 0; //L/R direction
    int speed = 10;
    float speedMod = 1;
    float downSpeed = 1; //prevent player from pushing through walls of bricks

    RectTransform arrowRT;
    public Image arrow;
    private const float minheldtime = 0.25f;
    private float spacepressedtime = 0;
    private bool spaceheld = false;
    private int i = 1;
    private bool unencumbered = true;
    private bool carryingMax = false;
    public GameObject grabField;
    public GameObject craneBody;
    private int antiClip = 1;

    private bool isClip = false;

    private bool defeated;
    void Start()
    {
        arrowRT = arrow.GetComponent<RectTransform>();
        
    }


    void Update()
    {
        isClip = craneBody.GetComponent<DetectClipping>().isClipping;
        defeated = GetComponent<CraneDestroyed>().failed;
        carryingMax = grabField.GetComponent<Grab>().maxCap;
        unencumbered = grabField.GetComponent<Grab>().canGrabmore;
        SpeedAdjust();
        if (!defeated)
        {
            if (isClip && dir == -1)
            {
                antiClip = 0;
                Debug.Log("STOP CHEATING!");
            }
            else
            {
                antiClip = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spacepressedtime = Time.timeSinceLevelLoad;
                spaceheld = false;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!spaceheld)
                {//space bar tapped

                    if (i == 1)
                    {
                        dir = 1;
                        sdir = 0;
                        arrowRT.Rotate(new Vector3(0, 0, 180));
                        i++;
                    }
                    else if (i == 2)
                    {
                        dir = 0;
                        sdir = -1;
                        arrowRT.Rotate(new Vector3(0, 0, -90));
                        i++;
                    }
                    else if (i == 3)
                    {
                        dir = 0;
                        sdir = 1;
                        arrowRT.Rotate(new Vector3(0, 0, 180));
                        i++;
                    }
                    else if (i == 4)
                    {
                        dir = -1;
                        sdir = 0;
                        arrowRT.Rotate(new Vector3(0, 0, 90));
                        i++;
                    }
                }

            }
            if (i == 5)
            {
                i = 1;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.timeSinceLevelLoad - spacepressedtime > minheldtime)
                {
                    spaceheld = true;
                    transform.Translate(Vector3.up * antiClip * dir * downSpeed * speed * speedMod * Time.deltaTime, Space.World);
                    transform.Translate(Vector3.left * sdir * speed * speedMod * Time.deltaTime, Space.World);
                }
            }
        }
    }


    void SpeedAdjust()
    {
        if (unencumbered)
            speedMod = 1f;
        else
            speedMod = 0.4f;

        //if (carryingMax && dir == -1)
         //   downSpeed = 0.1f;
      //  else
       //     downSpeed = 1f;

    }
}
