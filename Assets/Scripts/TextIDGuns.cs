using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextIDGuns : MonoBehaviour
{
    [SerializeField] int textID;
    GameObject gameControl;
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(0.02f);
        gameControl = FindObjectOfType<GameControl>().gameObject;

        if (gameControl.GetComponent<GameControl>().guns[textID])
        {
            gameObject.SetActive(false);
        }
    }
}
