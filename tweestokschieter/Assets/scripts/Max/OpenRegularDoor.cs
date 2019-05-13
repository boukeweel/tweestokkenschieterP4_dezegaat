using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class OpenRegularDoor : MonoBehaviour
{
    public GameObject Player;
    public float range;
    public LayerMask layerMask;
    public Animator animator;
    public int IsOpen = 1;


    void Update()
    {
        {
            if (XCI.GetButtonDown(XboxButton.Y, XboxController.First) || Input.GetKeyDown(KeyCode.F))
            {
                IsOpen = 0;
                Open();
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
                animator.SetBool("active", true);
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
                        animator.SetBool("active", false);
                    }
                }
            }
        }
    }

}
