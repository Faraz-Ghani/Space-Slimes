using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public BulletGenerator BulletGenerator;
    float shootStart=-2f;
    float CooldownTime=2f;
    //int ammo=3;
    bool ammo = true;
    public GameObject Player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject Reloading;
    public AudioSource Shootfx;
    // Update is called once per frame
    public void Update()
    {
        
    }
    public void Shoot()
    {
        if (!(shootStart + CooldownTime < Time.time)) return;


        if (Time.timeScale > 0 )
        {
            Shootfx.Play();
            shootStart = Time.time;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(Reloading, transform.position+new Vector3(0,1.5f,0), transform.rotation);

            print(transform.position + new Vector3(0, 10, 0));

        }
    }

    /*public void Pickup()
    {
        ammo++;
        BulletGenerator.randomizer();

    }
    */


}
