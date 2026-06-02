using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;

public class PauseManager : MonoBehaviour
{
    public Volume gv;
    public float blurAmount = 0.75f;
    public float blurTarget = 0.75f;
    public bool paused = false;
    public float smoothness = 5;
    public float smoothness2 = 5;
    public bool isInProgress;
    public GameObject pauseMenu;
    public AnimationClip fadeOut;
    public bool animInP = false;
    public bool canPause = true;
    public bool won = false;
    public GameObject wonObj;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        isInProgress = false;
        animInP = false;
        canPause = true;
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isInProgress)
            {
                paused = !paused;
            }

            if (paused)
            {
                blurTarget = 1;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }

            else
            {
                if (!animInP && pauseMenu.activeSelf)
                {
                    StartCoroutine(FadeOut());
                }

            }
        }

        if (won)
        {
            blurTarget = 1;
            wonObj.SetActive(true);
        }
        if (blurTarget >= blurAmount)
        {
            blurAmount += (blurTarget - blurAmount) / smoothness;
        }

        else
        {
            blurAmount += (blurTarget - blurAmount) / smoothness2;
        }
        if (Mathf.Abs(blurAmount - blurTarget) < 0.05f)
        {
            blurAmount = blurTarget;
        }

        isInProgress = !(blurAmount == blurTarget);

        gv.weight = blurAmount;

    }

    IEnumerator FadeOut()
    {
        print("Hi");
        pauseMenu.GetComponent<Animator>().Play("Fade Out");
        animInP = true;

        yield return new WaitForSecondsRealtime(fadeOut.length);

        pauseMenu.SetActive(false);
        animInP = false;

        blurTarget = 0f;
        Time.timeScale = 1;
    }
}
