using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPick;
    public float min, max;
    public float currentspeed;
    // Start is called before the first frame update
    void Awake()
    {
        generateBullet();
    }   
    public void randomizer()
    {
        float randomWait = Random.Range(min, max);

        print(randomWait);
        Invoke("generateBullet", randomWait);
  
    }
    void generateBullet()
    {

        GameObject bulletpick = Instantiate(BulletPick, transform.position, transform.rotation);
        bulletpick.GetComponent<BulletPickUpScript>().BulletGenerator = this;
    }
}
