using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//scrapped
public class BulletPickUpScript : MonoBehaviour
{
    Vector2 _startPosition;
    public BulletGenerator BulletGenerator;


    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        
        transform.position += new Vector3(-1 * BulletGenerator.currentspeed, 0.5f * Mathf.Sin(Time.time*2), 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    
        if (collision.gameObject.CompareTag("finishline"))
        {
            BulletGenerator.randomizer();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("nextline"))
        {//fix double spawn on start

        }
    }
}
