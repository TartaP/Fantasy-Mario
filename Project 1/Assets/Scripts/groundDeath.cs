using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
    

        collision.gameObject.GetComponent<Health>().TakeDamage(3);


        

        

    }

}
