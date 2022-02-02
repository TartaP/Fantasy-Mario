using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class Timelimemanager : MonoBehaviour
{
    private bool fix = false;
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;
    // Start is called before the first frame update
    void Enabled()
    {
        playerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing && !fix)
    
        {
            fix = true;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }
    }


    public void StartTimeline()
    {
        


        StartCoroutine(poletimer());
        Debug.Log("cutsceneSuccess");
        
    }
    IEnumerator poletimer()
    {
        yield return new WaitForSeconds(1.5f);
        director.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndScreen");

    }
}
