using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100;
    public float Damage = 20;
    public float Armor = 0;
    public GameObject UI;
    public bool TakeDamage = false;
    public int takingDamage;

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
        stadesmanger.DamgesTakenCount(Damage);
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

    public void EnemyHealth(int damges)
    {
        
        health -= damges;
        health = Mathf.Clamp(health, 0, 100);
        takingDamage++;
        if (health <= 0)
        {
            stadesmanger.EnemysKilledcount();
            Destroy(gameObject);
        }
    }
}
