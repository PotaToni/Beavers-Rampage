using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsMadeThisGame : MonoBehaviour
{

    GameObject coins;
    [SerializeField] Text text;




    void Start()
    {
        coins = FindObjectOfType<GameControl>().gameObject;
    }

    void Update()
    {
        text.text = coins.GetComponent<GameControl>().GetCoins().ToString();
    }




}
