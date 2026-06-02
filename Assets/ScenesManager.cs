using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public PauseManager pauseManager;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeScene(int amount)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + amount);
    }

    public void FixTime()
    {
        pauseManager.won = false;
        pauseManager.paused = false;
        Time.timeScale = 1;
    }
}
