using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HealthSystem
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            
            EnemyHealth();
        }
    }
}
