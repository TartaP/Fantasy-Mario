using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
     private int startingLives;
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
        }
        else
        {
            // Gameover
            GetComponent<Character>().enabled = false;
        }
    
    }
}
