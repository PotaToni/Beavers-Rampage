using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] AudioMixer audioMixer;
    GameObject gameControl;
    private string playStoreID = "3749225";
    private string appStoreID = "3749224";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlaystore;
    public bool isTestAd;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Ads");
        if (objs.Length > 1)
        {
            Destroy(objs[1]);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisment();
    }

    private void InitializeAdvertisment()
    {
        if (isTargetPlaystore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }

        Advertisement.Initialize(appStoreID, isTestAd);
    }


    public void PlayInterstitialAd()
    {
        if (!(Advertisement.IsReady(interstitialAd)))
        {
            return;
        }


        Advertisement.Show(interstitialAd);

    }


    public void PlayRewardedVideoAd()
    {
        if (!(Advertisement.IsReady(rewardedVideoAd)))
        {
            return;
        }

        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        AudioListener.volume = 0;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        gameControl = FindObjectOfType<GameControl>().gameObject;
        switch (showResult)
        {
            case ShowResult.Failed:
                AudioListener.volume = 1;
                if (placementId == rewardedVideoAd)
                {
                    FindObjectOfType<AdTimer>().gameObject.GetComponent<AdTimer>().Cancel();
                }
                break;
            case ShowResult.Skipped:
                AudioListener.volume = 1;
                break;
            case ShowResult.Finished:
                AudioListener.volume = 1;
                if (placementId == rewardedVideoAd)
                {
                    gameControl.GetComponent<GameControl>().WatchedMoneyAd();
                }
                break;
        }
    }
}
