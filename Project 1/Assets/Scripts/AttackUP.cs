using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUP : Collectible
{
   override public void pickUP(Character player)
    {
        player.attackUP();
        Debug.Log("fire");
    }
}
