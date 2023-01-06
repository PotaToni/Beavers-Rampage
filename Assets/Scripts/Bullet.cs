using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float speed = 10f;
    [SerializeField] float damageIncreasePer1000Score = 5;
    GameObject highScore;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Triggerer")
        {
        }
    }


    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            highScore = FindObjectOfType<HighScoreCounter>().gameObject;
            damage += (int)Math.Ceiling((damageIncreasePer1000Score / 1000) * (int)highScore.transform.position.x);
            Debug.Log(damage);
        }
        
    }

    public int GetDamage()
    {
        return damage;
    }


    public float GetSpeed()
    {
        return speed;
    }



}
