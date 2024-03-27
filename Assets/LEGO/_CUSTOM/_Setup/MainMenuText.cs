using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuText : MonoBehaviour
{
    public GameObject hold;
    public GameObject tap;
    void Start()
    {
        StartCoroutine("Toggle");
    }

   IEnumerator Toggle()
    {
        yield return new WaitForSeconds(3);
        hold.SetActive(false);
        tap.SetActive(true);
        yield return new WaitForSeconds(3);
        hold.SetActive(true);
        tap.SetActive(false);
        StartCoroutine("Toggle");
    }
}
