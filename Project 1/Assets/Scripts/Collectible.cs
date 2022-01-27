using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{

    
    public string itemType;
    
     public abstract void pickUP(Character player);

   
}
