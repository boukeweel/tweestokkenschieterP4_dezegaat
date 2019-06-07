using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapen : MonoBehaviour
{
    public AmmoSystem weapontype;

    int ammo;

    private void Start()
    {
        weapontype.ammo = ammo;
    }
}
