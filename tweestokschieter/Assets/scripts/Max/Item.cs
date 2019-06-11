using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;
    public Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();  
    }

    public void ItemUsage()
    {
        if(type == "Health")
        {
            player.Addhealth(25);
        }
    }

    public void RemoveItem()
    {
        for (int i = 0; i < ID; i++)
        {
            if(i == 3)
            {
                Destroy(icon);
            }
        }
    }
}
