using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunsData
{
    public bool[] guns;

    public GunsData(GameControl gameControl)
    {
        guns = gameControl.gameObject.GetComponent<GameControl>().guns;
    }

}
