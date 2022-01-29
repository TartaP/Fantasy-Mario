using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    private int currentHealth;

    private void Awake ()
    {
        
        currentHealth = startingHealth;
    }
    public void gainHealth()
    {
        currentHealth++; 
    }
    public void TakeDamage(int _damage)
    {
        currentHealth = currentHealth - _damage;



        if (currentHealth > 0)
        {
            //if hit once, character will get smaller
            Debug.Log(currentHealth);
            GetComponent<Character>().TakeDamage();

        }
        else
        {
            //when currenthealth goes to 0, life will go down

            GetComponent<Character>().PlayerDeath(); 
            


        }

    }
}
