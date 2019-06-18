using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades : MonoBehaviour
{
    public AmmoSystem hetweapon;

    public void Upgradeclipsize()
    {
        hetweapon.UpgradeClip();
    }
    public void shotgunnow()
    {
        if (weapen.firetype == weaponfiretype.shotgun)
        {
            Debug.Log("already shotgun");
        }
        else
        {
            hetweapon.UpgradeToShutgun();
        }

    }
    public void autofirenow()
    {
        if (weapen.firetype == weaponfiretype.autofire)
        {
            Debug.Log("alraedy autofire");
        }
        else
        {
            hetweapon.UpgradeToAutofire();
        }
    }
    public void simifirenow()
    {
        if(weapen.firetype == weaponfiretype.simifire)
        {
            Debug.Log("already simifire");
        }
        else
        {
            hetweapon.UpradeToSimifire();
        }
    }
    public void lessreloadtimer()
    {
        if(hetweapon.reloadTime < 0.5)
        {
            return;
        }
        hetweapon.upgradeRelaodtimer();
    }
    public void upgradeshootingspeed()
    {
        if(hetweapon.timetowait < 0.3)
        {
            return;
        }
        hetweapon.Upgradetimetowait();
    }
}
