using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLight : MonoBehaviour
{
    private GameObject player;
    private float speed = 2f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        Vector3 targetDirection = player.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
