using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] GameObject score;

    int newScore = 0;
    void Start()
    {
        
    }

    void Update()
    {

        newScore = (int)score.transform.position.x;
        text.text = newScore.ToString();
    }
}
