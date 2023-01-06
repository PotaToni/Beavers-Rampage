using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTriggerer : MonoBehaviour
{

    //also wind destroyer

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cloud")
        {
            collision.gameObject.GetComponent<Cloud>().SetMoveSpeed(-(collision.gameObject.GetComponent<Cloud>().GetMoveSpeed()));
        }


        if(collision.gameObject.tag == "Wind")
        {
            Destroy(collision.gameObject);
        }


    }



}
