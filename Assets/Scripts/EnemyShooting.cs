using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootPoint;
    [SerializeField] float timeBetweenShots = 1f;

    float baseTimeBetweenShots;

    private void Start()
    {
        baseTimeBetweenShots = timeBetweenShots;
    }



    void Update()
    {



        timeBetweenShots -= Time.deltaTime;

        if(timeBetweenShots <= 0)
        {


            Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);

            timeBetweenShots = baseTimeBetweenShots;

        }






        Vector3 difference = Camera.main.ScreenToWorldPoint(player.transform.position) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 45);



    }
}
