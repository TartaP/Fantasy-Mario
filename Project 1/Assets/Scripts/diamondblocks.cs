using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondblocks : MonoBehaviour
{
    public int totalCoins;

    private Animator anim;
    private bool opened = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
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
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.diamonds();
                    anim.SetTrigger("chestopen");
                    opened = true;
                    return;
                }

            }
        }




    }
}
