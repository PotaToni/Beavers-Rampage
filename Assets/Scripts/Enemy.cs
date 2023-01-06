using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] int health = 100;
    [SerializeField] GameObject coin;
    [SerializeField] float healthIncreasePer1000Score = 20;
    GameObject player;
    GameObject highScore;
    Bullet bullet;

    BlockSpawner camera;
    GameObject gameControl;

    void Start()
    {
        highScore = FindObjectOfType<HighScoreCounter>().gameObject;
        health += (int)Math.Ceiling((healthIncreasePer1000Score / 1000) * (int)highScore.transform.position.x);
        Debug.Log(health);
        player = FindObjectOfType<Player>().gameObject;
        camera = GameObject.FindObjectOfType<BlockSpawner>();
        gameControl = FindObjectOfType<GameControl>().gameObject;
        //transform.position = new Vector3(transform.position.x, transform.position.y, -4);


        if(UnityEngine.Random.Range(0,2) == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            transform.rotation = new Quaternion(0, 180, 0, 0);
            speed = -speed;
        }
        
    }

    private void Update()
    {


        if (camera.transform.position.x + 8.5f > transform.position.x && player != null && SceneManager.GetActiveScene().buildIndex != 2)
        {
            GetComponent<BulletInstantiate>().enabled = true;
        }
    }


    public float GetSpeed()
    {
        return speed;
    }

    public float SetSpeed(float speed)
    {
        this.speed = speed;
        return this.speed;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            bullet = collision.gameObject.GetComponent<Bullet>();
            health -= bullet.GetDamage();
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                if (gameControl.GetComponent<GameControl>().vibration)
                {
                    Handheld.Vibrate();
                }
                Destroy(gameObject);

                for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
                {
                    Instantiate(coin, transform.position, Quaternion.identity);
                }

            }

        }
    }


}
