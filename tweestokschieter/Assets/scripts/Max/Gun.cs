using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;

    public void ShootGun()
    {
        if(XCI.GetButtonDown(XboxButton.X, XboxController.First))
        {
#if UNITY_EDITOR
            print("werkt");
#endif
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}
