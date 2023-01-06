using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{

    [SerializeField] int coinsCollectedThisGame = 0;
    [SerializeField] int coins = 0;
    [SerializeField] int highScore = 0;
    [SerializeField] string leaderboard;
    [SerializeField] Text text;

    GameObject UIControl;
    bool canFindUIControl = false;
    public int playAdOnMenu = 0;
    public int playAdOnDeath = 0;
    public float volume = 1;

    public bool layout1 = true;
    public bool layout2 = false;
    public bool layout3 = false;

    public bool[] active;
    public bool[] owned;
    public bool[] guns;


    public bool vibration = false;

    private void Awake()
    {
        owned = new bool[6];
        active = new bool[8];
        guns = new bool[20];
        owned[0] = false;
        owned[1] = false;
        owned[2] = false;
        owned[3] = false;
        owned[4] = false;
        owned[5] = false;
        guns[0] = true;
        guns[1] = false;
        active[0] = false;
        active[1] = false;
        active[2] = false;
        active[3] = false;
        active[4] = false;
        active[5] = false;
        active[6] = true;
        active[7] = false;
        UIControl = FindObjectOfType<UIControl>().gameObject;


        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameControl");

        if (objs.Length > 1)
        {
            Destroy(objs[1]);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Succes");
                text.text = "Login successful";
            }
            else
            {
                Debug.Log("Login failed");
                text.text = "Login failed";
            }
        });

        //coinsCollectedThisGame = 69420;
        //highScore = 0;
        LoadPlayer();

        if(coins == 0)
        {
            FindObjectOfType<SceneLoader>().GetComponent<SceneLoader>().LoadTutorial();
        }
    }

    private void Update()
    {

        if (canFindUIControl)
        {
            UIControl = FindObjectOfType<UIControl>().gameObject;
            canFindUIControl = false;
        }
    }
    public int GetCoinsCollectedThisGame()
    {
        return coins;
    }

    public int GetCoins()
    {
        return coinsCollectedThisGame;
    }

    public void IncreaseCoinsCollectedThisGame()
    {
        coinsCollectedThisGame++;
    }

    public void SetHighScore(int finishedScore)
    {
        if(finishedScore > highScore)
        {
            highScore = finishedScore;
            SavePlayer();
            if (Social.localUser.authenticated)
            {
                Social.ReportScore(finishedScore, leaderboard, (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Score added");
                        }
                        else
                        {
                            Debug.Log("Update score failed");
                        }
                    });
            }
        }
    }

    public void SetUIControl(bool newCanSet)
    {
        canFindUIControl = newCanSet;
    }

    public void PurchaseMade(int costOfPurchase)
    {
        coins -= costOfPurchase;
        SavePlayer();
    }

    public void WatchedMoneyAd()
    {
        coinsCollectedThisGame *= 2;
        coins += coinsCollectedThisGame;
        coinsCollectedThisGame = 0;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        SaveSystem.SaveGuns(this);
    }

    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        GunsData gunsData = SaveSystem.LoadGun();

        owned = playerData.owned;
        coins = playerData.coins;
        highScore = playerData.highScore;
        guns = gunsData.guns;


    }


    public void IncreaseCoins()
    {
        coins += coinsCollectedThisGame;
        coinsCollectedThisGame = 0;
    }


    public void purchase1000()
    {
        coins +=1000;
    }

    public void purchase5000()
    {
        coins +=5000;
    }

    public void purchase10000()
    {
        coins +=10000;
    }

}
