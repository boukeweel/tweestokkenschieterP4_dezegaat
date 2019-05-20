using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int AmountAmmoget;
    public AmmoSystem ammosystem;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            stadesmanger.AmmoPickUpcount(AmountAmmoget);
            ammosystem.AddAmmo(AmountAmmoget);
            Destroy(gameObject);
        }
    }
}
