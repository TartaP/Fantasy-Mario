using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : Collectible
{
   override public void pickUP(Character player)
    {
        player.growUP();
        Debug.Log("grows");
    }

}
