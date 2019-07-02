using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume_test : MonoBehaviour
{
    
    void Update()
    {
        AudioListener.volume = UImanger.maxvolume;
    }
}
