using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{


    Enemy enemy;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-(enemy.GetSpeed()), 0);

                enemy.SetSpeed(-(enemy.GetSpeed()));

                if (enemy.GetSpeed() < 0)
                {
                    enemy.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                }
                else
                {
                    enemy.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }
        }
    }

}
