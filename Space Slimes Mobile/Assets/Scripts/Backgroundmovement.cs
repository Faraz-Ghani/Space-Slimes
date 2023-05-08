using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmovement : MonoBehaviour
{
    public float minspeed;
    public float maxspeed;
    public float currentspeed;
    public float speedmultipler;
    public Renderer backgroundRenderer;

    private void Awake()
    {
        currentspeed = minspeed;
    }
    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2 (currentspeed * Time.deltaTime, 0f);
        if (currentspeed < maxspeed)
        {
            currentspeed += speedmultipler;
        }
    }
}
