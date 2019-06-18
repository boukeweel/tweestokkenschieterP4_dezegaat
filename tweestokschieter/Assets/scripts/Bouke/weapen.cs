using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using XboxCtrlrInput;

public enum weaponfiretype
{
    simifire = 0,
    autofire,
    shotgun,
}
public class weapen : MonoBehaviour
{
    public AmmoSystem weapontype;

    float ammo;
    float magSize;
    float ammoalloudinclip;

    float reloadtimer;
    float ReloadTimer;

    float timetowait;

    bool Switchtoshotgun;
    bool Switchtoautofire;

    float holdtimetowait;

    private TextMeshProUGUI ammotext;
    private TextMeshProUGUI magsizetext;
    private TextMeshProUGUI ReloadTimer_;

    private GameObject bullet;

    private GameObject weaponPrefab;
    private GameObject parent;
    private GameObject weapon;


    private WeaponStatus weaponStatus;
    public weaponfiretype firetype;
    private void Start()
    {
        ammo = weapontype.ammo;
        ammoalloudinclip = weapontype.AmmoAlloudInClip;
        magSize = weapontype.magSize;
        reloadtimer = weapontype.reloadTime;
        ReloadTimer = weapontype.reloadTimer;
        timetowait = weapontype.timetowait;
        Switchtoshotgun = weapontype.Switchtoshotgun;
        Switchtoautofire = weapontype.Switchtoautofire;
        ammotext = weapontype.ammotext;
        magsizetext = weapontype.magsizetext;
        ReloadTimer_ = weapontype.ReloadTimer_;
        bullet = weapontype.bullet;
        weaponPrefab = weapontype.weaponPrefab;
        parent = weapontype.parent;
        weapon = weapontype.weapon;

        Debug.LogWarning("de enum is nu " + firetype);
        //Debug.Log("zoveel ammo" + magSize);
        ReloadTimer = 0f;
        holdtimetowait = timetowait;

    }
    public void Awake()
    {
        weaponStatus = WeaponStatus.ready;
       

    }
    
    public void reload()
    {
        weaponStatus = WeaponStatus.reloading;

    }

    public void setallfabriale()
    {
        ammo = weapontype.ammo;
        ammoalloudinclip = weapontype.AmmoAlloudInClip;
        magSize = weapontype.magSize;
        reloadtimer = weapontype.reloadTime;
        ReloadTimer = weapontype.reloadTimer;
        timetowait = weapontype.timetowait;
        Switchtoshotgun = weapontype.Switchtoshotgun;
        Switchtoautofire = weapontype.Switchtoautofire;
        ammotext = weapontype.ammotext;
        magsizetext = weapontype.magsizetext;
        ReloadTimer_ = weapontype.ReloadTimer_;
        bullet = weapontype.bullet;
        weaponPrefab = weapontype.weaponPrefab;
        parent = weapontype.parent;
        weapon = weapontype.weapon;
        Debug.LogWarning("de enum is nu " + firetype);

        //Debug.Log("nu zoveel ammo" + magSize);
    }

    void Update()
    {

        //Debug.Log(ammo);
        //if (Input.GetKeyDown(KeyCode.R) || XCI.GetButtonDown(XboxButton.X, XboxController.First))
        //{
        //    if (ammo < magSize)
        //    {
        //        //StartCoroutine(reloader());

        //    }
        //}

        if (Input.GetKeyDown(KeyCode.R) || XCI.GetButtonDown(XboxButton.X, XboxController.First))
        {
            if (ammo < magSize)
            {
                weaponStatus = WeaponStatus.reloading;

            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            magSize = 10000;
        }

        if (weaponStatus == WeaponStatus.reloading)
        {
            ReloadTimer += Time.deltaTime;

            if (ReloadTimer >= reloadtimer)
            {
                ReloadSystem();
            }
        }
        
        if (Input.GetMouseButtonDown(0) || XCI.GetAxis(XboxAxis.RightTrigger, XboxController.First) > 0.1)
        {
                Shoot();
        }
        
        
        
        timetowait -= Time.deltaTime;



        //ammotext.text = ammo.ToString();
        //magsizetext.text = magSize.ToString();

    }

    public void Shoot()
    {
        if (weaponStatus == WeaponStatus.reloading)
        {
            return;
        }
        
        ammo = Mathf.Clamp(ammo, 0, ammoalloudinclip);
        if (firetype == weaponfiretype.shotgun)
        {
            Debug.Log("komt hij hier");

            if (ammo != 0)
            {
               
                if (timetowait <= 0)
                {
                    shotgun();
                }


            }
        }
        if(firetype == weaponfiretype.autofire)
        {
            if (ammo != 0)
            {

                if (timetowait <= 0)
                {
                    Shootautofire();
                }


            }
        }
        if(firetype == weaponfiretype.simifire)
        {
            if (ammo != 0)
            {

                if (timetowait <= 0)
                {
                    SHootSIMIFIRE();
                }


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
        weaponStatus = WeaponStatus.ready;

    }

    public void shotgun()
    {
        for (int i = 0; i < 8; i++)
        {
            //Quaternion projectilerotation = Quaternion.Euler(new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0));
            Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
        }
        ammo--;
        stadesmanger.shootcount();
        timetowait = holdtimetowait;


    }

    public void Shootautofire()
    {





        Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
        ammo--;
        stadesmanger.shootcount();

        timetowait = holdtimetowait;



    }
    public void SHootSIMIFIRE()
    {


        Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
        ammo--;
        stadesmanger.shootcount();

        timetowait = holdtimetowait;


    }

    public void AddAmmo(int AmmoAmount)
    {
        magSize += AmmoAmount;
    }

    public void BuildWeapon()
    {
        weapon = Instantiate<GameObject>(weaponPrefab, parent.transform.position, parent.transform.rotation);
        weapon.transform.parent = parent.transform;
    }

    public void SetParent(GameObject p)
    {
        parent = p;
        BuildWeapon();
    }
}
