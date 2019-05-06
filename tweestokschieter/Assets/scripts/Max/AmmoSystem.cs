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

        ShootGun();

        ReloadGun();

    }

    private void ReloadGun()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (magSize < magSize)
            {
                ReloadSystem();
            }
        }
    }

    private void ReloadSystem()
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
