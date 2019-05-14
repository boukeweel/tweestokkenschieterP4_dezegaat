using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class OpenRegularDoor : MonoBehaviour
{
    public GameObject Player;
    public float range;
    public LayerMask layerMask;
    public LayerMask layerMask1;
    public LayerMask layerMask2;
    public LayerMask layerMask3;
    public LayerMask layerMask4;
    public Animator [] animator;
    public int IsOpen = 1;


    void Update()
    {
            if (XCI.GetButtonDown(XboxButton.Y, XboxController.First) || Input.GetKeyDown(KeyCode.F))
            {
                IsOpen = 0;
                Open();
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
        if(Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask1))
        {
            if (IsOpen == 0)
            {
                animator[1].SetBool("active", true);
                IsOpen = 1;
            }
        }
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask2))
        {
            if (IsOpen == 0)
            {
                animator[2].SetBool("active", true);
                IsOpen = 1;
            }
        }
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask3))
        {
            if (IsOpen == 0)
            {
                animator[3].SetBool("active", true);
                IsOpen = 1;
            }
        }
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask4))
        {
            if (IsOpen == 0)
            {
                animator[4].SetBool("active", true);
                IsOpen = 1;
            }
        }



    }

    void Close()
    {
        if (IsOpen == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
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
