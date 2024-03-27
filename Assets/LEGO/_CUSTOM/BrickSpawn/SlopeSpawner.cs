using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeSpawner : MonoBehaviour
{
    List<GameObject> slots = new List<GameObject>();
    public int max = 46;


    public GameObject brick;
    public GameObject brick2;
    public GameObject ball;
    public GameObject empty;
    void Start()
    {
       
    }

    void Update()
    {
        GameObject clone;
        if (slots.Count < max)
        {

            for (int i = 0; i < max; i++)
            {
                int brickVal = 0;
                int rand = Random.Range(0, 4);

                if(rand == 0)
                {
                    brickVal = 0;
                }else if(rand == 1)
                {
                    brickVal = 1;
                }else if(rand == 2)
                {
                    brickVal = 2;
                }else if( rand == 3)
                {
                    brickVal = 3;
                }

                GameObject tbrick = empty;
                if (brickVal == 0)
                    tbrick = brick;
                else if (brickVal == 1)
                    tbrick = ball;
                else if (brickVal == 2)
                    tbrick = empty;
                else if (brickVal == 3)
                    tbrick = brick2;

                Vector3 pos = new Vector3((transform.position.x + (i * -1.6f)), transform.position.y, transform.position.z);
                Quaternion rot = Quaternion.identity;

                
                
                clone = Instantiate(tbrick, pos, rot);

                slots.Add(clone);
            }
        }
    }
}
