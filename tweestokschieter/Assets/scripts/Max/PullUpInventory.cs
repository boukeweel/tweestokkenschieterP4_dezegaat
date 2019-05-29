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
        Time.timeScale = 1f;
        panelAnmimation.SetBool("active", false);

    }

    public void ReverseAnimtion()
    {
        panelAnmimation.SetBool("active", true);
        inventoryActive = true;
    }

    public void SetTime()
    {
        Time.timeScale = 0f;
    }

     
}
