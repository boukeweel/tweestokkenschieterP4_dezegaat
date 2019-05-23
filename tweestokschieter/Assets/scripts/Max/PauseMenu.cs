using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    public static bool isPaused = false;
    public Player player;

    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.First) || Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                paused();
            }
        }
    } 

    void paused()
    {
        UI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = false;
    }

    public void Resume()
    {
        UI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Controls()
    {
        player.usingcontrols();
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }
}
