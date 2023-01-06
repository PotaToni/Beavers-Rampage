using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreChanger : MonoBehaviour
{
    GameObject gameControl;
    void Start()
    {
        gameControl = FindObjectOfType<GameControl>().gameObject;
        gameObject.GetComponent<Text>().text = gameControl.GetComponent<GameControl>().GetHighScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
