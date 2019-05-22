using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class UImanger : MonoBehaviour
{
    public GameObject mainmenu, credits, options, controls;

    public AudioMixer audiomixer;

    Resolution[] resolutions;

    public TMP_Dropdown ResolutionDropDown;

    public TMP_Dropdown Grapichshold;

    private static int holdnumber;


    private void Start()
    {
        // hold value
        Grapichshold.value = holdnumber;
        //mainmenu set true
        MainMenu();

        //set resultion
         resolutions = Screen.resolutions;
            
        ResolutionDropDown.ClearOptions();

        List<string> Options = new List<string>();

        int currentresolutions = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height;

            Options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutions = i;
            }
        }

        ResolutionDropDown.AddOptions(Options);
        ResolutionDropDown.value = currentresolutions;
        ResolutionDropDown.RefreshShownValue();

    }
    /// <summary>
    /// Go to first lvl
    /// </summary>
    public void StartGame()
    {
        //start game
        SceneManager.LoadScene("Loading Scene");
        
    }
    /// <summary>
    /// Go to credits scene
    /// </summary>
    public void Credits()
    {
        //credits to true
        mainmenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
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
        controls.SetActive(false);
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
        controls.SetActive(false);
        credits.SetActive(false);
    }
    /// <summary>
    /// go to the control scherm
    /// </summary>
   public void Controls()
   {
        //controls to true
        mainmenu.SetActive(false);
        options.SetActive(false);
        controls.SetActive(true);
        credits.SetActive(false);
   }
    // go to statics scene
    public void gotostatics()
    {
        //go to states
        SceneManager.LoadScene(2);
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
        audiomixer.SetFloat("Volume", volume);
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
