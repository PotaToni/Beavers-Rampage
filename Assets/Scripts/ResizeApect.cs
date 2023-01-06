using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeApect : MonoBehaviour
{
    void Start()
    {
        if(Camera.main.aspect > 1.8f)
        {
            transform.localScale = new Vector3(transform.localScale.x +3.9f, transform.localScale.y,transform.localScale.z);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
