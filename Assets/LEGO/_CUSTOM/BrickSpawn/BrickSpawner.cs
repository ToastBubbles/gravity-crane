using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    List<GameObject> slots = new List<GameObject>();
    int max = 39;


    public GameObject longBrick;
    public GameObject shortBrick;
    public GameObject empty;
    int changeCheck;
    bool hasEmpty = false;
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
                int rand = Random.Range(0, 2);

                if (rand == 0 && changeCheck == rand || changeCheck != rand && hasEmpty == true && rand == 0)
                {
                    brickVal = 0;
                    hasEmpty = false;
                }
                else if (rand == 1 && changeCheck != rand || changeCheck == rand && hasEmpty == true && rand == 1) 
                { 
                    brickVal = 1;
                    hasEmpty = false;
                }
                else if ((hasEmpty == false && changeCheck != rand && rand == 0) || (hasEmpty == false && changeCheck == rand && rand == 1))
                {
                    brickVal = 2;
                    hasEmpty = true;
                }

                GameObject brick = empty;
                if (brickVal == 0)
                    brick = shortBrick;
                else if (brickVal == 1)
                    brick = longBrick;
                else if (brickVal == 2)
                    brick = empty;
                if (i == (max-1) && hasEmpty == false)
                    brick = shortBrick;
                   
                Vector3 pos = new Vector3((transform.position.x + (i * -1.6f)), transform.position.y, transform.position.z);
                Quaternion rot = Quaternion.identity;

                changeCheck = rand;
                
                clone = Instantiate(brick, pos, rot);

                slots.Add(clone);
            }
        }
    }
}
