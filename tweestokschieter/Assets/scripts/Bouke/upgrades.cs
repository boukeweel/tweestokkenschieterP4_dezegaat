using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class upgrades : MonoBehaviour
{
    public AmmoSystem hetweapon;

    public TMP_Text Shutguntext;
    public TMP_Text autofiretext;
    public TMP_Text simifiretext;
    public TMP_Text ClipUpgradetext;
    public TMP_Text reloadtimerText;
    public TMP_Text Shootingspeedtext;

    
    
    public void Upgradeclipsize()
    {
        hetweapon.UpgradeClip();
    }
    public void shotgunnow()
    {
        if (weapen.firetype == weaponfiretype.shotgun)
        {
            Debug.Log("already shutgun");
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
