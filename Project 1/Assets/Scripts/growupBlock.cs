using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growupBlock : MonoBehaviour
{
    private Animator anim;
    private bool opened = false;

    public Rigidbody2D growpotionAppear; 




    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (opened == true)
        {
            return;
        }
        for (int i = 0; i < col.contactCount; i++)
        {
            if (Vector2.Dot(Vector2.up, col.GetContact(i).normal) > 0.5f)
            {
                if (col.collider.tag == "Player")
                {
                    anim.SetTrigger("chestopen");
                    //anim.SetTrigger("diamondappearss");
                    
                    Instantiate(growpotionAppear, transform.position + (new Vector3(0, (float)1.3, 0)), Quaternion.identity);                    
                    opened = true;
                    return;
                    
                }

            }
        }
    }

}
