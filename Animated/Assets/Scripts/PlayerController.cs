using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   Animator anim;
   public AudioClip I_AM_TABLEMAN;
   public AudioClip The_Great_Escape;
   public AudioSource musicSource;
   public AudioSource musicSourceTwo;
   private Rigidbody2D rb2d;
   public GameObject Spaceship;
   public GameObject SpaceshipTwo;
   public GameObject SpaceshipThree;
   public GameObject SpaceshipFour;
   public GameObject SpaceshipFive;
   public GameObject SpaceshipSix;
   public float speed;
   public float jumpForce;
   private int count;
   private int lives;
   public Text countText;
   public Text livesText;
   public Text winText;
    void Start()
    {
        anim = GetComponent<Animator> ();
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = " ";
        SetCountText ();
        SetLivesText ();
    }

   
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal,0);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    
    }  

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }

          if (count == 4)
        {
            lives = 3;
            SetLivesText();
        }



        if (other.gameObject.CompareTag ("UFO"))
        {
            other.gameObject.SetActive (false);
            lives = lives -1;
            SetLivesText ();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString ();
        if (count == 4)
        {
            transform.position = new Vector3(80,-5,0);
        }

          if (count >= 9)
        {
            winText.text = "You Win!";
            musicSourceTwo.Play();
        }
    }

    void SetLivesText()
    {
        
        livesText.text = "Lives: " + lives.ToString ();
        if (lives <= 0)
        {
            winText.text = "You Lose!";
            Destroy(this);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            }
        }    
        
    }




  void Update()
    {
        musicSource.clip = I_AM_TABLEMAN;
        musicSourceTwo.clip = The_Great_Escape;
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            musicSource.Play();
        }

      



        //Cat runs right when D is pressed
        if (Input.GetKeyDown (KeyCode.D))
        {
            anim.SetInteger("State",2);
        }
        if (Input.GetKeyUp (KeyCode.D))
        {
            anim.SetInteger("State",0);
        }

        //Cat jumps when W is pressed.
          if (Input.GetKeyDown (KeyCode.W))
        {
            anim.SetInteger("State",1);
        }
            if (Input.GetKeyUp (KeyCode.W))
        {
            anim.SetInteger("State",0);
        }

        //Cat runs left when A is pressed.
          if (Input.GetKeyDown (KeyCode.A))
        {
            anim.SetInteger("State",3);
        }
            if (Input.GetKeyUp (KeyCode.A))
        {
            anim.SetInteger("State",0);
        }



        Spaceship.gameObject.transform.position = new Vector3(-7, Mathf.PingPong(Time.time*2, 10), 0);
        SpaceshipTwo.gameObject.transform.position = new Vector3(1, Mathf.PingPong(Time.time*2, 9), 0);
        SpaceshipThree.gameObject.transform.position = new Vector3(91, Mathf.PingPong(Time.time*2, 9), 0);
        SpaceshipFour.gameObject.transform.position = new Vector3(80 + Mathf.PingPong(Time.time*2, 20), -2, 0);
        SpaceshipFive.gameObject.transform.position = new Vector3(16, Mathf.PingPong(Time.time*2, 5), 0);
        SpaceshipSix.gameObject.transform.position = new Vector3(-16, Mathf.PingPong(Time.time*2, 8), 0);
    }
}
