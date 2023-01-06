using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public bool[] owned;
    public int coins;
    public int highScore;


    public PlayerData(GameControl gameControl)
    {
        owned = gameControl.gameObject.GetComponent<GameControl>().owned;
        coins = gameControl.gameObject.GetComponent<GameControl>().GetCoinsCollectedThisGame();
        highScore = gameControl.gameObject.GetComponent<GameControl>().GetHighScore();
    }




}
