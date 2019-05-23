using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullUpInventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Animator panelAnmimation;

    public bool inventoryActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryActive)
            {
                PlayeAnimaiton();
             
            }
            else
            {
                ReverseAnimtion();
            }
        }

    }

    public void PlayeAnimaiton()
    {
        inventoryActive = false;
        panelAnmimation.SetBool("active", false);
        Time.timeScale = 1f;
    }

    public void ReverseAnimtion()
    {
        panelAnmimation.SetBool("active", true);
        inventoryActive = true;
      
    }
}
