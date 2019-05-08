using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using XboxCtrlrInput;


public class AmmoSystem : MonoBehaviour
{
    [SerializeField]private float ammo;
    [SerializeField] private float magSize;
    [SerializeField] private GameObject bullet;

    [SerializeField] private TextMeshProUGUI ammotext;
    public TextMeshProUGUI magsizetext;

    void Update()
    {
        ammo = Mathf.Clamp(ammo, 0, 25f);

        if(ammo != 0)
        {
            ShootGun();
        }

        Debug.Log(ammo);
        if (Input.GetKeyDown(KeyCode.R) || XCI.GetButtonDown(XboxButton.X, XboxController.First))
        {
            if (ammo < magSize)
            {
                ReloadSystem();
            }
        }

        ammotext.text = ammo.ToString();
        magsizetext.text = magSize.ToString();

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
        if (Input.GetMouseButtonDown(0) || XCI.GetButtonDown(XboxButton.RightBumper, XboxController.First))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            ammo--;

        }
    }
    public void AddAmmo(int AmmoAmount)
    {
        magSize += AmmoAmount;
    }
}
