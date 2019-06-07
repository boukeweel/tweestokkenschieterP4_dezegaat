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

    public bool inventoryAnimDone = false;

    private void Update()
    {
        if (inventoryAnimDone == true)
        {
            for (int i = 0; i < allSlots; i++)
            {
                if (ingredient1 >= 3 && ingredient2 >= 1 && ingredient3 >= 2 )
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
            if (Input.GetKey(KeyCode.F))
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
