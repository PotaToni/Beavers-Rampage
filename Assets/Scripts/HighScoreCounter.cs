using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreCounter : MonoBehaviour
{

    [SerializeField] float movingSpeed = 1f;
    [SerializeField] GameObject player;

    GameObject gameControl;

    void Start()
    {
        gameControl = FindObjectOfType<GameControl>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<CameraMover>().enabled)
        {
            movingSpeed = Camera.main.GetComponent<CameraMover>().GetMovingSpeed();
        }
        else
        {
            movingSpeed = 0;
        }
        transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);

            gameControl.GetComponent<GameControl>().SetHighScore((int)transform.position.x);


    }
}
