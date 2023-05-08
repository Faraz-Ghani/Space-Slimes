using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public SpikeGenerator SpikeGenerator;
    public GameObject SpikeDeath;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * SpikeGenerator.currentspeed * Time.deltaTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextline"))
        {
            SpikeGenerator.randomizer();
        }
        if (collision.gameObject.CompareTag("finishline"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet")){
            {
                GameObject DeadSpike = Instantiate(SpikeDeath, transform.position, transform.rotation);
                Destroy(gameObject);

           }
        }
    }


}
