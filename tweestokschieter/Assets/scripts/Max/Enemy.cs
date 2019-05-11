using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HealthSystem
{
   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            Health();
        }
    }
}
