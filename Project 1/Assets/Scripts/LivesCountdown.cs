using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesCountdown : MonoBehaviour
{
    private float timer;

    private void Awake()
    {
        GetComponent<Text>().text = "x" + (Life.currentLife + 1);
    } 

    private void Update()
    {
        timer += Time.deltaTime;


        if (GetComponent<Text>().text != "x" + Life.currentLife && timer > 2)
        {
            GetComponent<Text>().text = "x" + Life.currentLife;
        }

        if (timer > 4)
        {
            SceneManager.LoadScene("GameScene"); 
        }

    }

}
