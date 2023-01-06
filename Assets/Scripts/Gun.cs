using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject rotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(rotation.transform.rotation.x, 0, rotation.transform.rotation.z, rotation.transform.rotation.w);
    }
}
