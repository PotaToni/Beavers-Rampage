using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdTimer : MonoBehaviour
{
    [SerializeField] GameObject AdMenu;
    Slider slider;
    GameObject gameControl;

    void Start()
    {
        slider = GetComponent<Slider>();
        gameControl = FindObjectOfType<GameControl>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= Time.deltaTime;
        if(slider.value <= 0)
        {
            Cancel();
        }
    }



    public void Cancel()
    {
        AdMenu.SetActive(false);
        gameControl.GetComponent<GameControl>().IncreaseCoins();
        gameControl.GetComponent<GameControl>().SavePlayer();
    }


    public void WatchAd()
    {
        FindObjectOfType<Ads>().PlayRewardedVideoAd();
        AdMenu.SetActive(false);
    }


}
