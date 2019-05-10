using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float Damage = 20;
    public float Armor;
    public GameObject UI;

    public void Health()
    {
        health = Mathf.Clamp(health, 0, 100);
        Armor = Mathf.Clamp(Armor, 0, 100);

        if(Armor == 0)
        {
            health -= Damage;
            
        }
        if (Armor > 0)
        {
            Armor -= Damage;
            
        }
        
        if(health <= 0)
        {
            Time.timeScale = 0;
            UI.SetActive(true);
        }
    }
    public void Addhealth(int Healthget)
    {
        
        health += Healthget;
        health = Mathf.Clamp(health, 0, 100);
    }
    public void Addarmor(int armorget)
    {
        
        Armor += armorget;
        Armor = Mathf.Clamp(Armor, 0, 100);
    }
}
