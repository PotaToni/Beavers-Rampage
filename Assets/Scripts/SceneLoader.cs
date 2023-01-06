using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    GameObject gameControl;
    GameObject UIControl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        gameControl = FindObjectOfType<GameControl>().gameObject;
        gameControl.GetComponent<GameControl>().SetUIControl(true);
    }


    public void LoadMainGame()
    {
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            UIControl = FindObjectOfType<UIControl>().gameObject;
            UIControl.GetComponent<UIControl>().SetCanSetGameControl(true);
        }
            SceneManager.LoadScene(1);

    }

    public void LoadTutorial()
    {
        UIControl = FindObjectOfType<UIControl>().gameObject;
        UIControl.GetComponent<UIControl>().SetCanSetGameControl(true);
        SceneManager.LoadScene(2);

    }

}
