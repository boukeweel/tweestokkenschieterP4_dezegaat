﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGO;
    private Inventory inventory;
    public int itemCurrentStack;
    public int itemMaxStack;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
        RemoveItem();
    }

    private void Start()
    {
        slotIconGO = transform.GetChild(0);
        inventory.GetComponent<Inventory>();
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    public void RemoveItem()
    {
        item.GetComponent<Item>().RemoveItem();
    }
}
