using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{

    [SerializeField] AudioSource brickhitsound;

    void OnCollisionEnter2D(Collision2D col)
    {


        for (int i = 0; i < col.contactCount; i++)
        {
            if (Vector2.Dot(Vector2.up, col.GetContact(i).normal) > 0.5f)
            {
                if (col.collider.tag == "Player")
                {
                    brickhitsound.Play();
                                
                    
                }

            }
        }
    }
}
