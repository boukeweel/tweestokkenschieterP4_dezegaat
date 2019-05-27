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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("desk"))
        {
            if(Item1 > 1 && Item2 > 2 && Item3 > 3)
            {
                MakeHealthPotion();
            }
        }
    }

    public void MakeHealthPotion()
    {
        healthPotion++;
    }
}
