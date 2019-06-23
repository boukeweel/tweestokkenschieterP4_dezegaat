using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public int ID;
    public int itemUsed;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;
    public Player player;
    public Sprite temp;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        temp = icon;
    }

    public void ItemUsage()
    {
        if(type == "Health")
        {
            itemUsed++;
            RemoveItem();
            //player.Addhealth(25);
        }
    }

    public void RemoveItem()
    {
        for (int i = 0; i < itemUsed; i++)
        {
            Destroy(icon);
        }
    }
}

public class ItemDataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Start()
    {
       
    }
}
