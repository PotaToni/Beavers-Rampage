using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObjects : MonoBehaviour
{


    [SerializeField] GameObject deathSceneUI;
    [SerializeField] GameObject highScoreCounter;


    GameObject ads;
    GameObject gameControl;

    private void Start()
    {
        ads = FindObjectOfType<Ads>().gameObject;
        gameControl = FindObjectOfType<GameControl>().gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Cloud" && collision.gameObject.tag != "Wind" && collision.gameObject.tag != "Meteor")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            deathSceneUI.SetActive(true);
            if (gameControl.GetComponent<GameControl>().playAdOnDeath == 4)
            {
                ads.GetComponent<Ads>().PlayInterstitialAd();
                gameControl.GetComponent<GameControl>().playAdOnDeath = 0;
            }
            else
            {
                gameControl.GetComponent<GameControl>().playAdOnDeath += 1;
            }
            gameControl.GetComponent<GameControl>().SavePlayer();
            highScoreCounter.GetComponent<HighScoreCounter>().enabled = false;
            Camera.main.GetComponent<CameraMover>().enabled = false;
        }

    }

}
