using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private float startingLives;
    private float life;

    private void Awake ()
    {
        life = startingLives;
    }

    public void TakeDamage(float _damage)
    {
        life = Mathf.Clamp(life - _damage, 0, startingLives);

        if (life > 0)
        {

        }
        else
        {
            
        }
    
    }
}
