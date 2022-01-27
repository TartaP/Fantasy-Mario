using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneUP : Collectible
{
   override public void pickUP(Character player)
    {
        player.gainLife();
        Debug.Log("itworks");
    }
}
