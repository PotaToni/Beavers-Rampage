using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeChange : MonoBehaviour
{

    [SerializeField] GameObject blockSpawner;
    [SerializeField] GameObject background;

    bool canStart = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            canStart = true;
            StartCoroutine(Waiting());
        }
    }


    public bool GetCanStart()
    {
        return canStart;
    }

    public void SetCanStart(bool start)
    {
        canStart = start;
    }



    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.5f);
    }


}
