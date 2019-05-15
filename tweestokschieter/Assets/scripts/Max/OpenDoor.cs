using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class OpenDoor : KeycardPickup
{
    public GameObject Player;
    public float range;
    public LayerMask layerMask;
    public LayerMask layerMask2;
    public Animator[] animator;
    public int IsOpen = 1;
    

    void Update()
    {
        if(keyCardPickedUp == true)
        {
            if (XCI.GetButtonDown(XboxButton.Y, XboxController.First) || Input.GetKeyDown(KeyCode.F))
            {
                IsOpen = 0;
                Open();
            }
        }

        if(keyCardPickedUp2 == true)
        {
            if (XCI.GetButtonDown(XboxButton.Y, XboxController.First) || Input.GetKeyDown(KeyCode.F))
            {
                IsOpen = 0;
                Open2();
            }
        }

    }

    void Open()
    {
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask))
        {
            if (IsOpen == 0)
            {
                animator[0].SetBool("active", true);
                IsOpen = 1;
            }
        }
    }

    void Open2()
    {
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask2))
        {
            if (IsOpen == 0)
            {
                animator[1].SetBool("active", true);
                IsOpen = 1;
            }
        }
    }

        void Close()
    {
        if(IsOpen == 1)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit hit;
                if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask))
                {
                    if (IsOpen == 0)
                    {
                        animator[0].SetBool("active", false);
                    }
                }
            }
        }
    }

   

}
