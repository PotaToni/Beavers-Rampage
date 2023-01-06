using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunID : MonoBehaviour
{
    [SerializeField] int gunID;
    GameObject gameControl;
    void Start()
    {
        gameControl = FindObjectOfType<GameControl>().gameObject;
        if (!(gameControl.GetComponent<GameControl>().active[gunID]))
        {
            gameObject.SetActive(false);
        }
    }


    public int GetGunID()
    {
        return gunID;
    }
}
