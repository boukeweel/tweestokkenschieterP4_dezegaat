using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Transform[] weapons;
    [SerializeField] private Transform player;
    private bool gunInHand;

    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.CompareTag("");
    }
}
