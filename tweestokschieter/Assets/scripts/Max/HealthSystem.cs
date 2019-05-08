using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float Damage;
    public GameObject UI;

    public void Health()
    {
        health = Mathf.Clamp(health, 0, 100);

        health -= Damage;
        if(health <= 0)
        {
            Time.timeScale = 0;
            UI.SetActive(true);
        }
    }
    public void addhealth(int Healthget)
    {
        health = Mathf.Clamp(health, 0, 100);
        health += Healthget;
    }
}
