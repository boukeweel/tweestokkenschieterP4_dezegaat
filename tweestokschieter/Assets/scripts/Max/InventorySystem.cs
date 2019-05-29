using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public int Item1;
    public int Item2;
    public int Item3;
    public int healthPotion;
    public LayerMask layerMask;

    public TextMeshProUGUI Item1Text;
    public TextMeshProUGUI Item2Text;
    public TextMeshProUGUI Item3Text;
    public TextMeshProUGUI potionText;

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
                    if (Item1 >= 3 && Item2 >= 1 && Item3 >= 3)
                    {
                        MakeHealthPotion();
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
        healthPotion++;
        Item1 = Item1 - 3;
        Item2 = Item2 - 1;
        Item3 = Item3 - 3;
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
