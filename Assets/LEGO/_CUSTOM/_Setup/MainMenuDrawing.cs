using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDrawing : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    void Start()
    {
        StartCoroutine("Toggle");
    }

   IEnumerator Toggle()
    {
        yield return new WaitForSeconds(0.5f);
        one.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        one.SetActive(true);
        two.SetActive(false);
        StartCoroutine("Toggle");
    }
}
