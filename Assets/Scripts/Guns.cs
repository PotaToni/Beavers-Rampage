using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangePosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangePosition()
    {
        yield return new WaitForSeconds(0.05f);
        gameObject.SetActive(false);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

}
