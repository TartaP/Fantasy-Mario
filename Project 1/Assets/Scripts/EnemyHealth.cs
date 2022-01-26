using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    private int enemycurrentHealth;

    private void Awake ()
    {
        
        enemycurrentHealth = enemyHealth;
    }

    public void TakeDamage(int _damage)
    {
        enemycurrentHealth = enemycurrentHealth - _damage;

        if (enemycurrentHealth > 0)
        {
            //if hit once, character will get smaller
            
        }
        else
        {
            //when currenthealth goes to 0, life will go down
            


        }
    
    }
}
