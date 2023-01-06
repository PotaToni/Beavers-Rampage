using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] GameObject meteor;

    Vector3 vector;
    GameObject instantiatedMeteor;

    float initialTimeBetweenSpawns;

    void Start()
    {
        initialTimeBetweenSpawns = timeBetweenSpawns;
    }


    void Update()
    {
        timeBetweenSpawns -= Time.deltaTime;

        if(timeBetweenSpawns <= 0)
        {
            vector = new Vector3(transform.position.x + Random.Range(-7, 7), transform.position.y, transform.position.z);
            instantiatedMeteor = Instantiate(meteor, new Vector3(transform.position.x + Random.Range(-7, 7), transform.position.y, transform.position.z) , Quaternion.identity);
            timeBetweenSpawns = initialTimeBetweenSpawns;
        }

    }
}
