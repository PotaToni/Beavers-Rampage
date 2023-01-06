using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] float push = 1f;
    [SerializeField] int meteorDamage = 20;
    GameObject player;
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grass" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Instantiated Block")
        {
            if (transform.position.x > player.transform.position.x)
            {
                if (transform.position.x - 2 < player.transform.position.x)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x - push, player.GetComponent<Rigidbody2D>().velocity.y);
                    Debug.Log("manje");
                }
            }

            if (transform.position.x < player.transform.position.x)
            {
                if (transform.position.x + 2 > player.transform.position.x)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x + push, player.GetComponent<Rigidbody2D>().velocity.y);
                    Debug.Log("vise");
                }
            }
            Destroy(gameObject);
        }

    }

    public int GetDamage()
    {
        return meteorDamage;
    }

}
