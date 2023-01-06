using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackground : MonoBehaviour
{

    [SerializeField] Material[] backgrounds;
    [SerializeField] GameObject[] music;

    void Start()
    {
        int randomNumber = Random.Range(0, backgrounds.Length);
        GetComponent<MeshRenderer>().material = backgrounds[randomNumber];
        switch (randomNumber)
        {
            case 0:
                music[1].SetActive(true);
                break;
            case 1:
                music[2].SetActive(true);
                break;
            case 2:
                music[6].SetActive(true);
                break;
            case 3:
                music[4].SetActive(true);
                break;
            case 4:
                music[3].SetActive(true);
                break;
            case 5:
                music[0].SetActive(true);
                break;
            case 6:
                music[5].SetActive(true);
                break;
        }
    }

    void Update()
    {
        
    }
}
