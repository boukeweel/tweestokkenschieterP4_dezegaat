using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanger : MonoBehaviour
{
    public GameObject mainmenu, credits, options, controls;
    private void Start()
    {
        mainmenu.SetActive(true);
        options.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void Credits()
    {
        mainmenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(true);

    }
    public void Options()
    {
        mainmenu.SetActive(false);
        options.SetActive(true);
        controls.SetActive(false);
        credits.SetActive(false);
    }
    public void MainMenu()
    {
        mainmenu.SetActive(true);
        options.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(false);
    }
   public void Controls()
   {
        mainmenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(true);
        credits.SetActive(false);
   }
    public void gotostatics()
    {
        SceneManager.LoadScene(2);
    }

    public void GameQuit()
    {
        Application.Quit();  
    }
}
