using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBulle : MonoBehaviour
{
    [SerializeField] float upJump = 1f;
    [SerializeField] float sideJump = 1f;
    [SerializeField] GameObject explosion;


    GameObject player;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            player = FindObjectOfType<Player>().gameObject;
            if(transform.position.x +3 > player.transform.position.x &&  player.transform.position.x > transform.position.x && player.transform.position.y < transform.position.y +2)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x + sideJump, player.GetComponent<Rigidbody2D>().velocity.y + upJump);
                player.GetComponent<Player>().ableToJump = true;
            }
            else if(player.transform.position.x +3 >transform.position.x && player.transform.position.y < transform.position.y + 2)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x - sideJump, player.GetComponent<Rigidbody2D>().velocity.y + upJump);
                player.GetComponent<Player>().ableToJump = true;
            }
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if(collision.gameObject.tag == "Instantiated Block")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}

