﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : Inventory
{
    
    public LayerMask layerMask;

 
    public TextMeshProUGUI potionText;

    public GameObject text;
    public Animator textAnimation;
    public Animator doorAnim;

    public GameObject button;

    public Animator animator;

    public bool inventoryActive = false;
    public bool inventoryAnimDone = false;
    public bool collision = false;

    private void Update()
    {
        if (inventoryAnimDone == true)
        {
            for (int i = 0; i < allSlots; i++)
            {
                if (scraps >= 1)
                {
                    button.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("desk"))
        {
            text.SetActive(true);
            textAnimation.SetBool("active", true);
            collision = true;

            if(collision == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                     if (inventoryActive)
                     {
                           inventoryAnimDone = true;
                           PlayeAnimaiton();
                     }
                     else
                     {
                         ReverseAnimtion();
                         inventoryAnimDone = false;
                         collision = false;
                     }
                }
            }
        }
        if(other.CompareTag("door"))
        {
            doorAnim.SetBool("active", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("desk"))
        {
            PlayeAnimaiton();
            textAnimation.SetBool("active", false);
        }
        if(other.CompareTag("door"))
        {
            doorAnim.SetBool("active", false);
        }
    }

    public void PlayeAnimaiton()
    {
        inventoryActive = false;
        Time.timeScale = 1f;
        animator.SetBool("active", false);
    }

    public void ReverseAnimtion()
    {
        animator.SetBool("active", true);
        inventoryActive = true;
    }

    public void SetTime()   
    {
        Time.timeScale = 0f;
    }

    public void AddToInventory()
    {
        Item item = health.GetComponent<Item>();

        Addhealth(item.ID, item.type, item.description, item.icon);
    }
}
