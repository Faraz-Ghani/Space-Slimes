using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Animator anim;
    private float speed = 20;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("nextline"))
        {
            Destroy(gameObject);
        }
        
        anim.SetBool("Hit", true);
        Destroy(gameObject,0.2f);
        
    }

}
    
    
