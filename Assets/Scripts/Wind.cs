using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float pushX = 3f;
    [SerializeField] float pushY = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, -3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log(collision.gameObject.name);

        if(collision.gameObject.tag == "Player" && collision.gameObject.name != "PlayerCollider")
        {
            
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x + pushX, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y + pushY);
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Dirt" || collision.gameObject.tag == "Grass" || collision.gameObject.tag == "Instantiated Block")
        {
            Destroy(gameObject);
        }

    }

}
