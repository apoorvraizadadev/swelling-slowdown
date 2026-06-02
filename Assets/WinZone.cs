using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public Timer timer;
    public PauseManager pauseManager;
    public TMP_Text time;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer.active = false;
            Time.timeScale = 0;
            pauseManager.canPause = false;
            pauseManager.won = true;
            time.text = "Best: " + timer.text.text;

            int sn = SceneManager.GetActiveScene().buildIndex;

            if (scoreManager.times[sn - 1] == -1)
            {
                scoreManager.times[sn - 1] = timer.time;
            }

            else
            {
                if (scoreManager.times[sn - 1] > timer.time)
                {
                    scoreManager.times[sn - 1] = timer.time;
                }
            }
        }
    }
}
