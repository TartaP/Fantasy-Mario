using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text diamondscoreText;

    int score = 00000;
    int diamondscore = 00;

    private void Awake ()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = string.Format("{0:D5}", score);
        diamondscoreText.text = string.Format("x{0:D2}", diamondscore);

    }

    // Update is called once per frame
    public void AddPoint()
    {
        diamondscore ++;
        diamondscoreText.text = string.Format("x{0:D2}", diamondscore);
    }

    public void diamonds()
    {

        score = score + 100;
        scoreText.text = string.Format("{0:D5}", score);
    }

    public void growth()
    {
        score = score + 1000;
        scoreText.text = string.Format("{0:D5}", score);
    }

    public void attackup()
    {
        score = score + 1000;
        scoreText.text = string.Format("{0:D5}", score);
    }

    public void goblinscore()
    {
        score = score + 100;
        scoreText.text = string.Format("{0:D5}", score);
    }

}
