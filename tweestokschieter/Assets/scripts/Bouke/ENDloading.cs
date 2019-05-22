using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDloading : MonoBehaviour
{
    public static int scenemanagement = 1;

    public void endloading()
    {
        SceneManager.LoadScene(scenemanagement);
        
    }
}
