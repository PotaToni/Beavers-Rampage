using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedAcross : MonoBehaviour
{

    [SerializeField] GameObject tutorialManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tutorialManager.GetComponent<Tutorial>().jumpedAcross = true;
        }
    }
}
