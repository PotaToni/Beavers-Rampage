using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject buyCoins;
    [SerializeField] Toggle toggle1;
    [SerializeField] Toggle toggle2;
    [SerializeField] Toggle toggle3;
    [SerializeField] Toggle gunToggle1;
    [SerializeField] Toggle gunToggle2;
    [SerializeField] Toggle gunToggle3;
    [SerializeField] Toggle gunToggle4;
    [SerializeField] Toggle gunToggle5;
    [SerializeField] Toggle gunToggle6;
    [SerializeField] Toggle gunToggle7;
    [SerializeField] Toggle gunToggle8;
    [SerializeField] Toggle toggleVibration;
    [SerializeField] GameObject textPrice2;
    [SerializeField] GameObject textPrice3;
    [SerializeField] GameObject textPrice4;
    [SerializeField] GameObject textPrice5;
    [SerializeField] GameObject textPrice6;
    [SerializeField] GameObject textPrice7;
    [SerializeField] GameObject textPrice1;


    [SerializeField] GameObject gunsPage2;

    [SerializeField] GameObject BlackedOut1;
    [SerializeField] GameObject BlackedOut2;
    [SerializeField] GameObject BlackedOut3;
    [SerializeField] GameObject BlackedOut4;
    [SerializeField] GameObject BlackedOut5;
    [SerializeField] GameObject BlackedOut6;

    [SerializeField] string leaderboard;
    [SerializeField] Text text;
    [SerializeField] GameObject ads;
    [SerializeField] GameObject purchaseMenu;

    GameObject settingsMenu;
    GameObject sceneLoader;
    GameObject layoutMenu;
    GameObject gunsMenu;
    GameObject gameControl;
    bool canSetGameControl = false;
    bool layout1 = true;
    bool layout2 = false;
    bool layout3 = false;

    bool[] guns;

    int gun1Price = 50;
    int gun2Price = 400;
    int gun3Price = 800;
    int gun4Price = 2000;
    int gun5Price = 10000;
    int gun6Price = 5000;

    bool vibration = false;




    public void BuyRocketLauncher()
    {
        IAPManager.instance.BuyRocketLauncher();
        purchaseMenu.SetActive(false);
        textPrice6.SetActive(false);
    }

    public void Buy1000Coins()
    {
        IAPManager.instance.BuyCoins1000();
    }

    public void Buy5000Coins()
    {
        IAPManager.instance.BuyCoins5000();
    }

    public void Buy10000Coins()
    {
        IAPManager.instance.BuyCoins10000();
    }






    private void Start()
    {
        //gunToggle1.isOn = true;
        guns = new bool[8];
        gameControl = FindObjectOfType<GameControl>().gameObject;
        sceneLoader = FindObjectOfType<SceneLoader>().gameObject;
        layoutMenu = FindObjectOfType<LayoutMenu>().gameObject;
        gunsMenu = FindObjectOfType<Guns>().gameObject;
        settingsMenu = FindObjectOfType<SettingsMenu>().gameObject;
        if (gameControl.GetComponent<GameControl>().playAdOnMenu == 3)
        {
            ads.GetComponent<Ads>().PlayInterstitialAd();
            gameControl.GetComponent<GameControl>().playAdOnMenu = 0;
        }
        else
        {
            gameControl.GetComponent<GameControl>().playAdOnMenu += 1;
        }
        toggle1.isOn = gameControl.GetComponent<GameControl>().layout1;
        toggle2.isOn = gameControl.GetComponent<GameControl>().layout2;
        toggle3.isOn = gameControl.GetComponent<GameControl>().layout3;

        gunToggle1.isOn = gameControl.GetComponent<GameControl>().active[0];
        gunToggle2.isOn = gameControl.GetComponent<GameControl>().active[1];
        gunToggle3.isOn = gameControl.GetComponent<GameControl>().active[2];
        gunToggle4.isOn = gameControl.GetComponent<GameControl>().active[3];
        gunToggle5.isOn = gameControl.GetComponent<GameControl>().active[4];
        gunToggle6.isOn = gameControl.GetComponent<GameControl>().active[5];
        gunToggle7.isOn = gameControl.GetComponent<GameControl>().active[6];
        gunToggle8.isOn = gameControl.GetComponent<GameControl>().active[7];

        layout1 = gameControl.GetComponent<GameControl>().layout1;
        layout2 = gameControl.GetComponent<GameControl>().layout2;
        layout3 = gameControl.GetComponent<GameControl>().layout3;

        guns[0] = gameControl.GetComponent<GameControl>().active[0];
        guns[1] = gameControl.GetComponent<GameControl>().active[1];
        guns[2] = gameControl.GetComponent<GameControl>().active[2];
        guns[3] = gameControl.GetComponent<GameControl>().active[3];
        guns[4] = gameControl.GetComponent<GameControl>().active[4];
        guns[5] = gameControl.GetComponent<GameControl>().active[5];
        guns[6] = gameControl.GetComponent<GameControl>().active[6];
        guns[7] = gameControl.GetComponent<GameControl>().active[7];

        toggleVibration.isOn = gameControl.GetComponent<GameControl>().vibration;
        vibration = toggleVibration.isOn;
        Debug.Log(settingsMenu.name);

    }
    private void Update()
    {
        if (canSetGameControl)
        {
            gameControl.GetComponent<GameControl>().layout1 = layout1;
            gameControl.GetComponent<GameControl>().layout2 = layout2;
            gameControl.GetComponent<GameControl>().layout3 = layout3;

            gameControl.GetComponent<GameControl>().active[0] = guns[0];
            gameControl.GetComponent<GameControl>().active[1] = guns[1];
            gameControl.GetComponent<GameControl>().active[2] = guns[2];
            gameControl.GetComponent<GameControl>().active[3] = guns[3];
            gameControl.GetComponent<GameControl>().active[4] = guns[4];
            gameControl.GetComponent<GameControl>().active[5] = guns[5];
            gameControl.GetComponent<GameControl>().active[6] = guns[6];
            gameControl.GetComponent<GameControl>().active[7] = guns[7];

            gameControl.GetComponent<GameControl>().vibration = vibration;
            canSetGameControl = false;
        }
    }

    public void SettingsOn()
    {
        //layoutMenu = FindObjectOfType<LayoutMenu>().gameObject;
        //settingsMenu = FindObjectOfType<SettingsMenu>().gameObject;
        settingsMenu.SetActive(true);
    }

    public void SettingsOff()
    {
        settingsMenu.SetActive(false);
    }


    public void LayoutOn()
    {
        layoutMenu.SetActive(true);
    }

    public void LayoutOff()
    {
        layoutMenu.SetActive(false);
    }


    public void GunsOn()
    {
        gunsMenu.SetActive(true);
        gunsPage2.SetActive(true);
    }
    public void GunsOff()
    {
        gunsMenu.SetActive(false);
        gunsPage2.SetActive(false);
    }


    public void SetLayout1 (bool isLayout)
    {
        layout1 = true;
        layout2 = false;
        layout3 = false;
    }

    public void SetLayout2(bool isLayout)
    {
        layout2 = true;
        layout1 = false;
        layout3 = false;
    }

    public void SetLayout3(bool isLayout)
    {
        layout3 = true;
        layout1 = false;
        layout2 = false;
    }


    public void SetGun1(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().owned[0])
        {
            gunToggle1.isOn = true;
            guns[0] = true;
            guns[1] = false;
            guns[2] = false;
            guns[3] = false;
            guns[4] = false;
            guns[5] = false;
            guns[6] = false;
            guns[7] = false;
        }
        else if (gameControl.GetComponent<GameControl>().GetCoinsCollectedThisGame() >= gun1Price)
        {
            gameControl.GetComponent<GameControl>().owned[0] = true;
            gameControl.GetComponent<GameControl>().PurchaseMade(gun1Price);
            textPrice1.SetActive(false);
            BlackedOut1.SetActive(false);
        }
    }

    public void SetGun2(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().owned[1])
        {
            gunToggle2.isOn = true;
            guns[0] = false;
            guns[1] = true;
            guns[2] = false;
            guns[3] = false;
            guns[4] = false;
            guns[5] = false;
            guns[6] = false;
            guns[7] = false;
        }

        else if (gameControl.GetComponent<GameControl>().GetCoinsCollectedThisGame() >= gun2Price)
        {
            gameControl.GetComponent<GameControl>().owned[1] = true;
            gameControl.GetComponent<GameControl>().PurchaseMade(gun2Price);
            textPrice2.SetActive(false);
            BlackedOut2.SetActive(false);
        }

    }


    public void SetGun3(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().owned[2])
        {
            gunToggle3.isOn = true;
            guns[0] = false;
            guns[1] = false;
            guns[2] = true;
            guns[3] = false;
            guns[4] = false;
            guns[5] = false;
            guns[6] = false;
            guns[7] = false;
        }

        else if (gameControl.GetComponent<GameControl>().GetCoinsCollectedThisGame() >= gun3Price)
        {
            gameControl.GetComponent<GameControl>().owned[2] = true;
            gameControl.GetComponent<GameControl>().PurchaseMade(gun3Price);
            textPrice3.SetActive(false);
            BlackedOut3.SetActive(false);
        }

    }

    public void SetGun4(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().owned[3])
        {
            gunToggle4.isOn = true;
            guns[0] = false;
            guns[1] = false;
            guns[2] = false;
            guns[3] = true;
            guns[4] = false;
            guns[5] = false;
            guns[6] = false;
            guns[7] = false;
        }

        else if (gameControl.GetComponent<GameControl>().GetCoinsCollectedThisGame() >= gun4Price)
        {
            gameControl.GetComponent<GameControl>().owned[3] = true;
            gameControl.GetComponent<GameControl>().PurchaseMade(gun4Price);
            textPrice4.SetActive(false);
            BlackedOut4.SetActive(false);
        }

    }

    public void SetGun5(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().owned[4])
        {
            gunToggle5.isOn = true;
            guns[0] = false;
            guns[1] = false;
            guns[2] = false;
            guns[3] = false;
            guns[4] = true;
            guns[5] = false;
            guns[6] = false;
            guns[7] = false;
        }

        else if (gameControl.GetComponent<GameControl>().GetCoinsCollectedThisGame() >= gun5Price)
        {
            gameControl.GetComponent<GameControl>().owned[4] = true;
            gameControl.GetComponent<GameControl>().PurchaseMade(gun5Price);
            textPrice5.SetActive(false);
            BlackedOut5.SetActive(false);
        }

    }


    public void SetGun6(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().owned[5])
        {
            gunToggle6.isOn = true;
            guns[0] = false;
            guns[1] = false;
            guns[2] = false;
            guns[3] = false;
            guns[4] = false;
            guns[5] = true;
            guns[6] = false;
            guns[7] = false;
        }

        else
        {
            purchaseMenu.SetActive(true);
        }

    }

    public void SetGun7(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().guns[0])
        {
            gunToggle7.isOn = true;
            guns[0] = false;
            guns[1] = false;
            guns[2] = false;
            guns[3] = false;
            guns[4] = false;
            guns[5] = false;
            guns[6] = true;
            guns[7] = false;
        }
        else if (gameControl.GetComponent<GameControl>().GetCoinsCollectedThisGame() >= gun1Price)
        {
            gameControl.GetComponent<GameControl>().owned[0] = true;
            gameControl.GetComponent<GameControl>().PurchaseMade(gun1Price);
            textPrice1.SetActive(false);
            BlackedOut1.SetActive(false);
        }
    }


    public void SetGun8(bool isLayout)
    {
        if (gameControl.GetComponent<GameControl>().guns[1])
        {
            gunToggle8.isOn = true;
            guns[0] = false;
            guns[1] = false;
            guns[2] = false;
            guns[3] = false;
            guns[4] = false;
            guns[5] = false;
            guns[6] = false;
            guns[7] = true;
        }
        else if (gameControl.GetComponent<GameControl>().GetCoinsCollectedThisGame() >= gun6Price)
        {
            gameControl.GetComponent<GameControl>().guns[1] = true;
            gameControl.GetComponent<GameControl>().PurchaseMade(gun6Price);
            textPrice7.SetActive(false);
            BlackedOut6.SetActive(false);
        }
    }


    public void CancelPurchase()
    {
        purchaseMenu.SetActive(false);
    }

    public void NextPage()
    {
        gunsPage2.transform.position = new Vector2(gunsPage2.transform.position.x, gunsMenu.transform.position.y);
        gunsMenu.SetActive(true);
    }

    public void LastPage()
    {
        gunsPage2.transform.position = new Vector2(gunsPage2.transform.position.x, -500);
        gunsMenu.SetActive(true);
    }

    public void ShowLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboard);
    }

    public void SetVibration(bool isVibration)
    {
        vibration = !vibration;
        Debug.Log(vibration);
    }

    public bool GetLayout()
    {
        return layout1;
    }

    public void SetCanSetGameControl(bool canSet)
    {
        canSetGameControl = canSet;
    }

    public void Login()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Succes");
            }
            else
            {
                Debug.Log("Login failed");
                text.text = "login failed";
            }
        });
    }


    public void BuyCoinsOn()
    {
        buyCoins.SetActive(true);
        gunsMenu.SetActive(false);
        gunsPage2.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void BuyCoinsOff()
    {
        buyCoins.SetActive(false);
    }


}
