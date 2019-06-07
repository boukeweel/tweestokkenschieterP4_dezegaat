using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] AmmoSystem weapon;

 

    public void OnCollisionEnter(Collision collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if(p != null)
        {
            p.SetWeapon(weapon);
            Destroy(gameObject);
        }
        
    }


}
