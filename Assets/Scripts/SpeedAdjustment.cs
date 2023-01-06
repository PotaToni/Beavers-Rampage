using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdjustment : MonoBehaviour
{
    [SerializeField] float speedIncrease = 0.5f;
    [SerializeField] GameObject background;


    CameraMover cameraMover;

    private void Start()
    {
        cameraMover = Camera.main.GetComponent<CameraMover>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            cameraMover.SetMovingSpeed(speedIncrease);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraMover.SetMovingSpeed(-speedIncrease);
        }
    }


}
