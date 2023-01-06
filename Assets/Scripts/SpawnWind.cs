using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWind : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] GameObject wind;


    GameObject windInstantiated;
    float timeBetweenSpawnsInitial;

    
    void Start()
    {
        timeBetweenSpawnsInitial = timeBetweenSpawns;
    }

    void Update()
    {
        timeBetweenSpawns -= Time.deltaTime;

        if(timeBetweenSpawns <= 0)
        {
            windInstantiated = Instantiate(wind, new Vector3(transform.position.x, transform.position.y + Random.Range(1, 8), 2f), transform.rotation) as GameObject;
            timeBetweenSpawns = timeBetweenSpawnsInitial;
            //windInstantiated.transform.parent = Camera.main.transform;
        }

    }


}
