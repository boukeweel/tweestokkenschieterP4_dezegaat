using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotions : MonoBehaviour
{
    private Player player; 

    public void UseHealthPotion()
    {
        player.health = player.health + 25;
    }
    
    public void UseArmorPotion()
    {

    }

    public void SpeedPotion()
    {

    }

}
