using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int AmountAmmoget;
    public AmmoSystem ammosystem;
    //[SerializeField] private GameObject Particle;
    private void Start()
    {
        
    }
    /// <summary>
    /// Add ammo to weapeons
    /// <summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Particle.SetActive(true);
            stadesmanger.AmmoPickUpcount(AmountAmmoget);
            //ammosystem.AddAmmo(AmountAmmoget);
            Destroy(gameObject);
        }
    }
}
