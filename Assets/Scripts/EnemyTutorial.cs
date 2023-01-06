using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTutorial : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] int health = 100;
    [SerializeField] float healthIncreasePer1000Score = 20;
    [SerializeField] GameObject tutorialManager;
    GameObject player;
    GameObject highScore;
    Bullet bullet;

    BlockSpawner camera;
    GameObject gameControl;

    void Start()
    {
        Debug.Log(health);
        player = FindObjectOfType<Player>().gameObject;
        camera = GameObject.FindObjectOfType<BlockSpawner>();
        gameControl = FindObjectOfType<GameControl>().gameObject;
        //transform.position = new Vector3(transform.position.x, transform.position.y, -4);


        if (UnityEngine.Random.Range(0, 2) == 0)
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
                Destroy(gameObject);
                tutorialManager.GetComponent<Tutorial>().tutorialFinished = true;

            }

        }
    }


}
