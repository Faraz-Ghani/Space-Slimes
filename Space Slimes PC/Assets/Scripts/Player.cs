using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameOverScript gameOverScript;
    public GameObject Button,StartText;
    private Animator anim;
    
    public float jumpforce;
    float score;
    bool isAlive = true;

    [SerializeField]
    bool isGrounded = false;
    public Weapon weapon;
    public AudioSource Music;
    public AudioSource Pause;
    public AudioSource Dead;

    Rigidbody2D rb;

    public Text Scoretxt;
    private void Awake()
    {   Pause.Play(); 
        anim = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>();
        score = 0;
      Time.timeScale = 0;
    }

    public void startgame()
    {
        Pause.Pause();
        Time.timeScale = 1;
        StartText.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);
        Scoretxt.gameObject.SetActive(true);
        Music.Play();
    }
    
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsRunning", isAlive);
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

   /* private void OnTriggerEnter2D(Collider2D collision)
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
