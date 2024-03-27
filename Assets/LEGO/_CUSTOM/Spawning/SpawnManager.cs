using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    List<GameObject> brickCollection = new List<GameObject>();
    int max = 3;
    public GameObject bricks;
    public int BrickSpawnChance = 80;
    void Start()
    {
        PlaceBricks();
    }


    void Update()
    {
        
    }

    void PlaceBricks()
    {
        for (int i = 0; i < max; i++)
        {
            int r = Random.Range(0, 100);
            if (r < BrickSpawnChance)
            {
                int rand = Random.Range(0, 3);
                GameObject clone;
                Vector3 pos = new Vector3(transform.position.x + 24.6f, transform.position.y + ((i + 1) * 8f), transform.position.z);
                Quaternion rot = Quaternion.identity;
                clone = Instantiate(bricks, pos, rot);
                brickCollection.Add(clone);
                if (rand < 2)
                {
                    Vector3 pos2 = new Vector3(transform.position.x + 24.6f, transform.position.y + (((i + 1) * 8f) - 1), transform.position.z);
                    Quaternion rot2 = Quaternion.identity;
                    clone = Instantiate(bricks, pos2, rot2);
                    rand++;
                }
                if (rand < 2)
                {
                    Vector3 pos2 = new Vector3(transform.position.x + 24.6f, transform.position.y + (((i + 1) * 8f) - 1), transform.position.z);
                    Quaternion rot2 = Quaternion.identity;
                    clone = Instantiate(bricks, pos2, rot2);
                    rand++;
                }
            }


        }
        
    }
}
