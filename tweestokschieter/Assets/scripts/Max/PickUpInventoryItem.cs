using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInventoryItem : InventorySystem
{
    private Collision collision;
    
    void Update()
    {
        Item1Text.text = Item1.ToString();
        Item2Text.text = Item2.ToString();
        Item3Text.text = Item3.ToString();
        potionText.text = healthPotion.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("item1"))
        {
            Item1++;
            Destroy(GameObject.FindGameObjectWithTag("item1"));
        }
        if (collision.collider.CompareTag("item2"))
        {
            Item2++;
            Destroy(GameObject.FindGameObjectWithTag("item2"));
        }
        if (collision.collider.CompareTag("item3"))
        {
            Item3++;
            Destroy(GameObject.FindGameObjectWithTag("item3"));
        }
    }

    private void DestroyItem()
    { 
        //foreach(GameObject go in tags)
        //{
        //    if(go != gameObject)
        //    {
        //        Destroy(go);
        //    }
        //}

    }
}
