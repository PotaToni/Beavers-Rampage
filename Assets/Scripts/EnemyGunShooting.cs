using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunShooting : MonoBehaviour
{

    Bullet bullet;
    Player player;

    Vector2 moveDirection;
    Rigidbody2D rb;




    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        if (player != null)
        {
            Debug.Log("bok");
            bullet = GetComponent<Bullet>();
            rb = GetComponent<Rigidbody2D>();
            moveDirection = (player.transform.position - transform.position).normalized * bullet.GetSpeed();
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }

    }

    void Update()
    {



    }



}
