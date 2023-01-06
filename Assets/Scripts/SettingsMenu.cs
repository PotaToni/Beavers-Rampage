using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{


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
        yield return new WaitForSeconds(0.04f);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        gameObject.SetActive(false);
    }
}
