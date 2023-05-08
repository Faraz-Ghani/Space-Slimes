using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;
    public float min, max;
    public float minspeed;
    public float maxspeed;
    public float currentspeed;
    public float speedmultipler;
    // Start is called before the first frame update
    void Awake()
    {
        currentspeed = minspeed;
        generateSpike();
    }
    public void randomizer()
    {
        float randomWait = Random.Range(min,max);
        Invoke("generateSpike", randomWait);
        
       
    }
    void generateSpike()
    {   
        GameObject Spike = Instantiate(spike,transform.position,transform.rotation);
        Spike.GetComponent<SpikeScript>().SpikeGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentspeed < maxspeed)
        {
            currentspeed += speedmultipler;
        }
    }
}
