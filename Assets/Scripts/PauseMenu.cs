using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    [SerializeField] GameObject pauseMenuUI;


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        if(FindObjectOfType<Player>() == null)
        {
            return;
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
