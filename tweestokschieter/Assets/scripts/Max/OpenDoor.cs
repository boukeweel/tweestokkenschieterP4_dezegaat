using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Player;
    public float range;
    public LayerMask layerMask;
    public Animator animator;
    public int IsOpen;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsOpen = 0;
            Open();
        }

        if (IsOpen == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Close();
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
