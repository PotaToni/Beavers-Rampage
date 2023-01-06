using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTutorial : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-3.84f, -0.87f, -1f);
        }
    }


}
