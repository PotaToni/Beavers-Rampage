using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject welcomeScreen;
    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject music;
    [SerializeField] Joystick movingJoystick;
    [SerializeField] GameObject rightCollider;
    [SerializeField] Text text;
    [SerializeField] GameObject goodbyeScreen;
    [SerializeField] GameObject sceneLoader;


    bool canAgain = true;
    bool movedLeft = false;
    bool movedRight = false;
    bool hasJumped = false;
    public bool tutorialFinished = false;
    public bool jumpedAcross = false;

    void Start()
    {
        StartCoroutine(TutorialTimeStamps());

    }

    // Update is called once per frame
    void Update()
    {
        if (movingJoystick.Horizontal > 0.2f)
        {
            movedLeft = true;
        }
        else if (movingJoystick.Horizontal < -0.2f)
        {

            movedRight = true;
        }

        if(movedRight && movedLeft)
        {
            text.text = "Great, now try to jump by dragging it up";
        }
        else
        {
            return;
        }

        if(movingJoystick.Vertical > 0.6f)
        {
            hasJumped = true;

        }

        if (hasJumped)
        {
            text.text = "Wow, could you jump to the other side by dragging it uppper right?";
            rightCollider.SetActive(false);
        }


        if (jumpedAcross)
        {
            text.text = "Okay now shoot the enemy with your right joystick!";
        }

        if (tutorialFinished && canAgain)
        {
            text.gameObject.SetActive(false);
            StartCoroutine(FinishTutorial());
            canAgain = false;
        }

    }


    public IEnumerator TutorialTimeStamps()
    {
        yield return new WaitForSeconds(5);
        text.gameObject.SetActive(true);
        welcomeScreen.SetActive(false);
        skipButton.SetActive(true);
        music.SetActive(true);
    }


    public IEnumerator FinishTutorial()
    {
        goodbyeScreen.SetActive(true);
        yield return new WaitForSeconds(12);
        sceneLoader.GetComponent<SceneLoader>().LoadMainMenu();
        
    }

}
