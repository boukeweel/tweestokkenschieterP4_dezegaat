using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public float Item1;
    public float Item2;
    public float Item3;
    public float healthPotion;

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
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (inventoryActive)
                {
                    PlayeAnimaiton();
                    if (Item1 > 1 && Item2 > 2 && Item3 > 3)
                    {

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
        if(other.CompareTag("desk"))
        {
            PlayeAnimaiton();
        }
    }

    public void MakeHealthPotion()
    {
        healthPotion++;
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
