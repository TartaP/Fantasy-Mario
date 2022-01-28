using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
     private int startingLives;

     private Animator anim;
     public static int currentLife = 3;

    private void Awake()
    {
        // currentLife = startingLives;
    }

    public void LoseLife()
    {
        currentLife = currentLife - 1;

        if (currentLife > 0)
        {
            // still have lives, Restart and keep playing

            SceneManager.LoadScene("LivesScreen");
            Debug.Log("currentLife " + currentLife);
            //anim.SetBool("death", true);
        }
        else
        {
            // Gameover
            GetComponent<Character>().enabled = false;
            
        }
    
    }

    public void GainLife()
    {
        currentLife++;
        
    }
}
