using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Collectible
{
   override public void pickUP(Character player)
    {
        player.diamondUP();
        Debug.Log("diamond");
    }
}
