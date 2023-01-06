using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiate : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] float timeBetweenShots = 1f;

    GameObject player;



    float timeOriginal;


    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        timeOriginal = timeBetweenShots;
    }

    void Update()
    {


        if(player == null)
        {
            enabled = false;
        }





        timeBetweenShots -= Time.deltaTime;

        if (timeBetweenShots <= 0)
        {
            Vector3 difference = player.transform.position - transform.position;

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, rotationZ));
            timeBetweenShots = timeOriginal;
            

        }




    }
}
