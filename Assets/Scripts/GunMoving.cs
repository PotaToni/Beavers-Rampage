using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMoving : MonoBehaviour
{

    [SerializeField] GameObject myPlayer;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootPoint;
    [SerializeField] Joystick joystick;
    [SerializeField] Joystick joystick2;
    [SerializeField] Joystick movingJoystick;
    [SerializeField] GameObject player;
    [SerializeField] float timeBetweenShots = 0.2f;
    [SerializeField] float offset = 45;

    Quaternion rotation;
    GameObject shotgunBullet1;
    GameObject shotgunBullet2;
    float negative = 1;
    GameObject gameControl;
    float startTimeBetweenShots;




    private void Start()
    {
        gameControl = FindObjectOfType<GameControl>().gameObject;
        startTimeBetweenShots = timeBetweenShots;
    }
    void Update()
    {

        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (!(gameControl.GetComponent<GameControl>().layout3))
        {
            if (!(player.GetComponent<Player>().moveLeft) && player.GetComponent<Player>().moveRight)
            {
                if(transform.rotation.z != 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                myPlayer.transform.rotation = new Quaternion(0, 0, 0, 0);
                negative = 1;
                //myPlayer.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.1f);


            }

            else if (player.GetComponent<Player>().moveLeft)
            {
                if (transform.rotation.z != 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    Debug.Log("12");
                    negative = 1;
                }
                else
                {
                    negative = 1;
                }
                myPlayer.transform.rotation = new Quaternion(0, 0, 0, 0);
                //myPlayer.transform.position = new Vector2(transform.position.x -0.2f, transform.position.y + 0.1f);

            }
            Vector3 difference = new Vector3(negative * joystick.Horizontal * 8 + Camera.main.transform.position.x, negative *joystick.Vertical * 4.5f, -5) - Camera.main.transform.position;

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);



            if (joystick.Vertical > 0.01f || joystick.Horizontal > 0.01f || joystick.Vertical < -0.01f || joystick.Horizontal < -0.01f)
            {
                if (timeBetweenShots <= 0)
                {
                    Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                    if(gameObject.GetComponent<GunID>().GetGunID() == 2)
                    {
                        shotgunBullet1 = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                        shotgunBullet1.name = "BulletUp";
                        shotgunBullet2 = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                        shotgunBullet2.name = "BulletDown";
                    }

                    timeBetweenShots = startTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
            }
        }
        else
        {
            if (!(player.GetComponent<Player>().moveLeft) && player.GetComponent<Player>().moveRight)
            {
                if (transform.rotation.z != 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                myPlayer.transform.rotation = new Quaternion(0, 0, 0, 0);
                negative = 1;
                //myPlayer.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.1f);


            }

            else if (player.GetComponent<Player>().moveLeft)
            {
                if (transform.rotation.z != 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    negative = 1;
                }
                negative = 1;
                myPlayer.transform.rotation = new Quaternion(0, 0, 0, 0);
                //myPlayer.transform.position = new Vector2(transform.position.x -0.2f, transform.position.y + 0.1f);

            }
            Vector3 difference = new Vector3(negative * joystick2.Horizontal * 8 + Camera.main.transform.position.x, negative * joystick2.Vertical * 4.5f, -5) - Camera.main.transform.position;

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);



            if (joystick2.Vertical > 0.01f || joystick2.Horizontal > 0.01f || joystick2.Vertical < -0.01f || joystick2.Horizontal < -0.01f)
            {
                if (timeBetweenShots <= 0)
                {
                    Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                    if (gameObject.GetComponent<GunID>().GetGunID() == 2)
                    {
                        shotgunBullet1 = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                        shotgunBullet1.name = "BulletUp";
                        shotgunBullet2 = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                        shotgunBullet2.name = "BulletDown";
                    }

                    timeBetweenShots = startTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
            }
        }





        /*if(rotationZ < -90 || rotationZ > 90)
        {
            if(myPlayer.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (myPlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }*/



    }
}
