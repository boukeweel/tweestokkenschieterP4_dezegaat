using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : Inventory
{
    
    public LayerMask layerMask;

    public TextMeshProUGUI Item1Text;
    public TextMeshProUGUI Item2Text;
    public TextMeshProUGUI Item3Text;
    public TextMeshProUGUI potionText;

    public GameObject button;

    public Animator animator;

    public bool inventoryActive = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("desk"))
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                if (inventoryActive)
                {
                    PlayeAnimaiton();
                    for (int i = 0; i < allSlots; i++)
                    {
                        if(ingredient1 > 0)
                        {
                            button.SetActive(true);
                            MakeHealthPotion();
                        }
                    }
                }
                else
                {
                    ReverseAnimtion();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("desk"))
        {
            PlayeAnimaiton();
        }
    }

    public void MakeHealthPotion()
    {
        button.SetActive(true);
        Debug.Log("potion");
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
}
