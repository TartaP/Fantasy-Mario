using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOVer : MonoBehaviour
{
    public void QuitGame ()
    {
        Debug.Log("QuitSuccess");
        Application.Quit();
    }
    public void playAgain ()
    {
        SceneManager.LoadScene("Firstlevel");
    }


}
