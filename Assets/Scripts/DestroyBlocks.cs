using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grass" || collision.gameObject.tag == "Dirt" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet") 
        {
            Destroy(collision.gameObject);
        }
    }

}
