using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnResize : MonoBehaviour
{

    //0 is left 1 is right

    [SerializeField] int rightOrLeft;
    [SerializeField] float resizeOffset;

    void Start()
    {
        if (Camera.main.aspect > 1.8f)
        {
            if(rightOrLeft == 0)
            {
                transform.position = new Vector2(transform.position.x - resizeOffset, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x + resizeOffset, transform.position.y);
            }
        }
    }

    void Update()
    {
        
    }
}
