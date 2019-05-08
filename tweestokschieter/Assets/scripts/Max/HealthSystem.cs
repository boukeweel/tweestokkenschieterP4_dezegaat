using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float Damage;

    public void Health()
    {
        health = Mathf.Clamp(health, 0, 100);

        Damage = Damage - health;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
