using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapen : MonoBehaviour
{
    public AmmoSystem weapontype;

    float ammo;
    float magsize;
    float ammoalloudinclip;

    float reloadtimer;
    float reloadtimes;

    private void Start()
    {
        weapontype.ammo = ammo;
        weapontype.AmmoAlloudInClip = ammoalloudinclip;
        weapontype.magSize = magsize;
        weapontype.reloadTime = reloadtimer;

    }
}
