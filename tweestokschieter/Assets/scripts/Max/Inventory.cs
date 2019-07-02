using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int allSlots;
    private GameObject[] slot;

    private int enabledSlots;
    public GameObject slotHolder;

    public GameObject health;

    private GameObject inventory;
    private bool inventoryEnabled;

    public int scraps;

    void Start()
    {
        allSlots = 14;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);

         
            if(item.ID == 6)
            {
                scraps++;
            }
        }
    }

    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if(slot[i].GetComponent<Slot>().empty)
            {
                //add item
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                return;
            }
        }
    }

    public void Addhealth(int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                //add item
                health.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = health;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                health.transform.parent = slot[i].transform;    
                health.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                return;
            }
        }
    }

    public void RemoveItem()
    {
        for (int i = 0; i < allSlots; i++)
        {
            if(slot[i].GetComponent<Slot>().item == health)
            {
                Destroy(slot[i].GetComponent<Slot>().slotIconGO);
            }
        }
    }
}
