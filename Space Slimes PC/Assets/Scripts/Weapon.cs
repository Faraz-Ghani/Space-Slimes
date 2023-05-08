using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float shootStart = -2f;
    float CooldownTime = 2f;
    bool ammo=true;
    public GameObject Player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject Reloading;
    public AudioSource Shootfx;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale>0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!(shootStart + CooldownTime < Time.time)) return;


        if (Time.timeScale > 0)
        {
            Shootfx.Play();
            shootStart = Time.time;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(Reloading, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);

            print(transform.position + new Vector3(0, 10, 0));

        }
    }

   


}
