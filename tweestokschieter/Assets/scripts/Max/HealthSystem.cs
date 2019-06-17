using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100;
    public float Damage = 5;
    public float Armor = 0;
    public GameObject UI;
    public bool TakeDamage = false;
    public int takingDamage;
    //public GameObject DroppedItem;
    

    public void Health(int damges)
    {

        Damage = damges;
        health = Mathf.Clamp(health, 0, 100);
        Armor = Mathf.Clamp(Armor, 0, 100);

        if (Armor == 0)
        {
            health -= Damage;
        }
        if (Armor > 0)
        {
            takingDamage = damges;
            Armor -= takingDamage;

        }

        stadesmanger.DamgesTakenCount(Damage);
        if (health <= 0)
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
            //Instantiate(DroppedItem, transform.position, transform.rotation);
            stadesmanger.EnemysKilledcount();
            Destroy(gameObject);
        }
    }
}
