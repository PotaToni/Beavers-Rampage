using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            moveSpeed = Random.Range(0.1f, 0.2f);
        }
        else
        {
            moveSpeed = Random.Range(-0.2f, -0.1f);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }


    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }



}
