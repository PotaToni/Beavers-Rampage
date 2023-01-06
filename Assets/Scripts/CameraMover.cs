using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float movingSpeed = 1f;




    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);


    }


    public void SetMovingSpeed(float movingSpeedOffset)
    {
        movingSpeed += movingSpeedOffset;
    }

    public void MoveCamera(float moveLenght)
    {
        transform.position = new Vector3(transform.position.x + moveLenght, transform.position.y, -10f);
    }

    public void MovingSpeedIs(float newMovingSpeed)
    {
        movingSpeed = newMovingSpeed;

    }

    public float GetMovingSpeed()
    {
        return movingSpeed;
    }



}
