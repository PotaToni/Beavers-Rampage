using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutMenu : MonoBehaviour
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
        if(Camera.main.aspect < 1.8f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3500);
        }
    }

}
