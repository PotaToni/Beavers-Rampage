using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{

    Bullet bullet;

    void Start()
    {
        bullet = GetComponent<Bullet>();
    }

    // Update is called once per frame
    void Update()
    {

        if(name == "BulletUp")
        {
           transform.Translate(Vector2.right * bullet.GetSpeed() /2 * Time.deltaTime);
            transform.Translate(Vector2.right * bullet.GetSpeed() /2* Time.deltaTime);
            transform.Translate(Vector2.up * bullet.GetSpeed()* Time.deltaTime);
        }
        else if(name == "BulletDown")
        {
            transform.Translate(Vector2.right * bullet.GetSpeed() /2 * Time.deltaTime);
            transform.Translate(Vector2.right * bullet.GetSpeed() /2 * Time.deltaTime);
            transform.Translate(Vector2.down * bullet.GetSpeed() * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * bullet.GetSpeed() * Time.deltaTime);
        }
        
        //transform.Translate(Vector2.up * speed * Time.deltaTime);

    }












}
