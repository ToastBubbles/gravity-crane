using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMat : MonoBehaviour
{
    private float scrollSpeedX = 0.1f;
    private float scrollSpeedY = 0.1f;
    public Material mat;
    void Start()
    {
        mat.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = scrollSpeedX * Time.time;
        float offsetY = scrollSpeedY * Time.time;
        mat.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));//move texture
    }
}
