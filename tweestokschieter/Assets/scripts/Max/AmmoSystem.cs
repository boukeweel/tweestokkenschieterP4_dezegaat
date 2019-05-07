using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSystem : MonoBehaviour
{
    public float ammo;
    public float magSize = 125;
    public GameObject bullet;

    void Update()
    {
        ammo = Mathf.Clamp(ammo, 0, 25f);

        if(ammo != 0)
        {
            ShootGun();
        }

        Debug.Log(ammo);
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (ammo < magSize)
            {
                ReloadSystem();
            }
        }

    }

    public void ReloadSystem()
    {
        for (float i = ammo; i < magSize; i++)
        {
            if (magSize <= 0) break;
            ammo++;
            magSize--;
        }
    }

    public void ShootGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            ammo--;

        }
    }
}
