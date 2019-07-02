using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class UImanger : MonoBehaviour
{
    public GameObject mainmenu, credits, options;

    public AudioMixer audiomixer;

    Resolution[] resolutions;

    

    public TMP_Dropdown Grapichshold;

    private static int holdnumber;
    //[Range(0.0f, 1.0f)]
    public static float maxvolume;



    private void Start()
    {

        
        // hold value
        Grapichshold.value = holdnumber;
        //mainmenu set true
        MainMenu();

     
        

    }
    /// <summary>
    /// Go to first lvl
    /// </summary>
    public void StartGame()
    {
        //start game
        SceneManager.LoadScene(1);
        
    }
    /// <summary>
    /// Go to credits scene
    /// </summary>
    public void Credits()
    {
        //credits to true
        mainmenu.SetActive(false);
        options.SetActive(false);
        
        credits.SetActive(true);

    }
    /// <summary>
    /// go to options 
    /// </summary>
    public void Options()
    {
        //options to true
        mainmenu.SetActive(false);
        options.SetActive(true);
        
        credits.SetActive(false);
    }
    /// <summary>
    /// go to Main menu
    /// </summary>
    public void MainMenu()
    {
        //mainmenu to true
        mainmenu.SetActive(true);
        options.SetActive(false);
        
        credits.SetActive(false);
    }
    /// <summary>
    /// go to the control scherm
    /// </summary>
   
    // go to statics scene
    public void gotostatics()
    {
        //go to states
        SceneManager.LoadScene(3);
    }

    //quit the game 
    public void GameQuit()
    {
        //quit game
        Application.Quit();  
    }


    //set options valuas

    //set vulume
    public void setvolume(float volume)
    {
        maxvolume = volume;
        
    }
    private void Update()
    {
        AudioListener.volume = maxvolume;
    }

    //set Graphics
    public void SetGraphics(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
        holdnumber = qualityindex;
    }

    //set fullscreen
    public void setfullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }

    //set resolution
    public void setresolution(int resolutionindex)
    {
        Resolution resolution_ = resolutions[resolutionindex];
        Screen.SetResolution(resolution_.width, resolution_.height, Screen.fullScreen);
    }
    
}
