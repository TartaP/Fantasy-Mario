using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Collectible
{

    private float lastTime;
    [SerializeField] private float maxlifeTime;

    void Awake()
    {
        Debug.Log("awake");
        lastTime = Time.time;
    }

    void Update()
    {
        
         if(Time.time - lastTime > maxlifeTime) 
            gameObject.SetActive(false);
    }
   override public void pickUP(Character player)
    {
       // player.diamondUP();
        Debug.Log("diamond");
    }
}
