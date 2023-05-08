using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameOverScript gameOverScript;
    public GameObject StartScreen,button1,button2;
    private Animator anim;

    public float jumpforce;
    float score;
    bool isAlive = true;

    [SerializeField]
    bool isGrounded = false;
    public Weapon weapon;
    public AudioSource Dead;
    public AudioSource Start;
    public AudioSource Music;

    Rigidbody2D rb;

    public Text Scoretxt;
    private void Awake()
    {
        Start.Play();
        anim = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>();
        score = 0;
      Time.timeScale = 0;
    }

    public void startgame()
    {
        Start.Pause();
        Music.Play();
        Time.timeScale = 1;
        StartScreen.gameObject.SetActive(false);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);

        Scoretxt.gameObject.SetActive(true);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            anim.SetBool("IsRunning", isAlive);
            jump();
            if (isGrounded == true)
            {
                isGrounded = false; 
                rb.AddForce(Vector2.up * jumpforce);
            }
        }
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            Scoretxt.text = "SCORE : " + ((int)score).ToString();
        }
    }

    public void jump()
    {
        if (isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpforce);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPickup"))
        {
            gameObject.GetComponentInChildren<Weapon>().Pickup();
            Destroy(collision.gameObject);
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded==false){
                isGrounded=true; 
            }
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            Music.Pause();
            Dead.Play();
            isAlive = false;
            gameOverScript.Setup((int)score);
            Scoretxt.gameObject.SetActive(false);
  
                Time.timeScale = 0;
        }
        
    }
   public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
