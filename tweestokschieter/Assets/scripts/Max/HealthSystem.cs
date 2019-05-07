using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int Damage;

    public void Health()
    {
        Damage = Damage - health;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
