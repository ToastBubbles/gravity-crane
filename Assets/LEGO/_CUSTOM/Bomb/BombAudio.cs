using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAudio : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
