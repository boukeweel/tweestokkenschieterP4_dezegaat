using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class upgrades : MonoBehaviour
{
    public AmmoSystem hetweapon;

    public Inventory inventory;

    public TMP_Text Shutguntext;
    public TMP_Text autofiretext;
    public TMP_Text simifiretext;
    public TMP_Text ClipUpgradetext;
    public TMP_Text reloadtimerText;
    public TMP_Text Shootingspeedtext;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void Upgradeclipsize()
    {
        if(inventory.scraps >= 1)
        {
            hetweapon.UpgradeClip();
            inventory.scraps--;
        }
    }

    public void shotgunnow()
    {
        if (inventory.scraps >= 3)
        {
            if (weapen.firetype == weaponfiretype.shotgun)
            {
                Debug.Log("already shutgun");
            }
            else
            {
                hetweapon.UpgradeToShutgun();
            }
            inventory.scraps--;
        }
    }

    public void autofirenow()
    {
        if(inventory.scraps >= 3)
        {
            if (weapen.firetype == weaponfiretype.autofire)
            {
                Debug.Log("alraedy autofire");
            }
            else
            {
                hetweapon.UpgradeToAutofire();
            }
            inventory.scraps = inventory.scraps - 3;
        }
    }

    public void simifirenow()
    {
        if (inventory.scraps >= 1)
        {
            if (weapen.firetype == weaponfiretype.simifire)
            {
                Debug.Log("already simifire");
            }
            else
            {
                hetweapon.UpradeToSimifire();
            }
            inventory.scraps--;
        }
    }

    public void lessreloadtimer()
    {
        if (inventory.scraps >= 2)
        {
            if (hetweapon.reloadTime < 0.5)
            {
                return;
            }
            hetweapon.upgradeRelaodtimer();
            inventory.scraps = inventory.scraps - 2;
        }
    }

    public void upgradeshootingspeed()
    {
        if (inventory.scraps >= 1)
        {
            if (hetweapon.timetowait < 0.3)
            {
                return;
            }
            hetweapon.Upgradetimetowait();
            inventory.scraps--;
        }
       
    }
}
