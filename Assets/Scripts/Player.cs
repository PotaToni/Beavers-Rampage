using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpHeight = 1f;
    [SerializeField] int health = 100;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject meteor;
    [SerializeField] Joystick joystick;
    [SerializeField] Joystick joystickFloating;
    [SerializeField] Joystick shootingJoystick;
    [SerializeField] GameObject deathSceneUI;
    [SerializeField] GameObject highScoreCounter;
    [SerializeField] GameObject layout1;
    [SerializeField] GameObject layout2;
    [SerializeField] GameObject layout3;
    [SerializeField] Animator anim;


    GameObject ads;

    GameObject gameControl;
    Bullet bullet;
    GameObject UIControl;
    public bool moveRight = false;
    public bool moveLeft = false;
    float deltaX;
    float newX;
    float verticalMove;

    public bool ableToJump = true;
    void Start()
    {
        ads = FindObjectOfType<Ads>().gameObject;
        gameControl = FindObjectOfType<GameControl>().gameObject;
        if (gameControl.GetComponent<GameControl>().layout1)
        {
            layout1.SetActive(true);
            layout2.SetActive(false);
            layout3.SetActive(false);
        }
        else if(gameControl.GetComponent<GameControl>().layout2)
        {
            layout1.SetActive(false);
            layout2.SetActive(true);
            layout3.SetActive(false);
        }
        else
        {
            shootingJoystick.gameObject.SetActive(false);
            layout1.SetActive(false);
            layout2.SetActive(false);
            layout3.SetActive(true);
        }

        if(healthBar != null)
        {
            healthBar.SetMaxHealth(health);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (highScoreCounter != null)
        {
            highScoreCounter.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && ableToJump )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
            ableToJump = false;

        }





        if (gameControl.GetComponent<GameControl>().layout1)
        {



            verticalMove = joystick.Vertical;
            if (verticalMove > 0.6f && ableToJump)
            {
                anim.SetBool("isJumping", true);
                anim.SetTrigger("jump");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
                ableToJump = false;
            }


            if (moveRight || moveLeft)
            {
                if (joystick.Horizontal < 0.2f || Input.GetKeyUp(KeyCode.D) == false)
                {
                    StopMovingRight();
                }


                if (joystick.Horizontal > -0.2f || Input.GetKeyUp(KeyCode.A) == false)
                {
                    StopMovingLeft();
                }
            }


            if (joystick.Horizontal > 0.2f || Input.GetKey(KeyCode.D) == true)
            {
                MoveRight();
            }
            else if (joystick.Horizontal < -0.2f || Input.GetKey(KeyCode.A) == true)
            {

                MoveLeft();
            }
        }
        else if (gameControl.GetComponent<GameControl>().layout3)
        {
            verticalMove = joystickFloating.Vertical;
            if (verticalMove > 0.6f && ableToJump)
            {
                anim.SetBool("isJumping", true);
                anim.SetTrigger("jump");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
                ableToJump = false;
            }


            if (moveRight || moveLeft)
            {
                if (joystickFloating.Horizontal < 0.2f)
                {
                    StopMovingRight();
                }


                if (joystickFloating.Horizontal > -0.2f)
                {
                    StopMovingLeft();
                }
            }


            if (joystickFloating.Horizontal > 0.2f)
            {
                MoveRight();
            }
            else if (joystickFloating.Horizontal < -0.2f)
            {
                MoveLeft();
            }
        }

        newX = transform.position.x + deltaX;
        transform.position = new Vector2(newX, transform.position.y);


        if (moveRight)
        {
            var deltaXright = Time.deltaTime * moveSpeed;
            var newXright = transform.position.x + deltaXright;
            transform.position = new Vector2(newXright, transform.position.y);
        }

        if (moveLeft)
        {
            var deltaXleft = Time.deltaTime * moveSpeed;
            var newXleft = transform.position.x - deltaXleft;
            transform.position = new Vector2(newXleft, transform.position.y);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.collider.gameObject.tag == "Dirt") && !(collision.collider.gameObject.tag == "Triggerer"))
        {

            ableToJump = true;
            anim.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Wind")
        {
            ableToJump = true;
        }



        if (collision.gameObject.tag == "EnemyBullet")
        {
            bullet = collision.gameObject.GetComponent<Bullet>();
            health -= bullet.GetDamage();
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                gameControl.GetComponent<GameControl>().SavePlayer();
                Destroy(gameObject);
                deathSceneUI.SetActive(true);
                if (gameControl.GetComponent<GameControl>().playAdOnDeath == 4)
                {
                    ads.GetComponent<Ads>().PlayInterstitialAd();
                    gameControl.GetComponent<GameControl>().playAdOnDeath = 0;
                }
                else
                {
                    gameControl.GetComponent<GameControl>().playAdOnDeath += 1;
                }
                //highScoreCounter.GetComponent<HighScoreCounter>().enabled = false;
                Camera.main.GetComponent<CameraMover>().enabled = false;
            }
            healthBar.SetHealth(health);

        }



        if (collision.gameObject.tag == "Meteor")
        {
            health -= meteor.GetComponent<Meteor>().GetDamage();

            if (health <= 0)
            {
                gameControl.GetComponent<GameControl>().SavePlayer();
                Destroy(gameObject);
                deathSceneUI.SetActive(true);
                if (gameControl.GetComponent<GameControl>().playAdOnDeath == 4)
                {
                    ads.GetComponent<Ads>().PlayInterstitialAd();
                    gameControl.GetComponent<GameControl>().playAdOnDeath = 0;
                }
                else
                {
                    gameControl.GetComponent<GameControl>().playAdOnDeath += 1;
                }
                //highScoreCounter.GetComponent<HighScoreCounter>().enabled = false;
                Camera.main.GetComponent<CameraMover>().enabled = false;
            }
            healthBar.SetHealth(health);

        }


    }





    public void MoveRight()
    {
        moveRight = true;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        anim.SetBool("isRunning", true);

    }

    public void StopMovingRight()
    {
        moveRight = false;
        anim.SetBool("isRunning", false);

    }

    public void MoveLeft()
    {
        moveLeft = true;
        transform.rotation = new Quaternion(0, 0,0, 0);
        anim.SetBool("isRunning", true);
    }

    public void StopMovingLeft()
    {
        moveLeft = false;
        anim.SetBool("isRunning", false);

    }

    public void Jump()
    {
        if (ableToJump)
        {
            anim.SetBool("isJumping", true);
            anim.SetTrigger("jump");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
            ableToJump = false;
        }
    }


    public int GetHealth()
    {
        return health;
    }
}
