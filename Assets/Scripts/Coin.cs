using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 10f;
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 10f;
    GameObject coinsMadeThisGameText;





    void Start()
    {
        coinsMadeThisGameText = FindObjectOfType<GameControl>().gameObject;
        GetComponent<Rigidbody2D>().velocity = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            coinsMadeThisGameText.GetComponent<GameControl>().IncreaseCoinsCollectedThisGame();
        }

    }



}
