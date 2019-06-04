using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using XboxCtrlrInput;

public enum WeaponStatus
{
    ready = 0,
    reloading
}

[CreateAssetMenu(fileName = "weapon", menuName ="scriptableobject/Weapons" , order =1)]
public class AmmoSystem : ScriptableObject
{

    [SerializeField] private float ammo;
    [SerializeField] private float magSize;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reloadTime;
    [SerializeField] private TextMeshProUGUI ammotext;
    public TextMeshProUGUI magsizetext;
    public TextMeshProUGUI ReloadTimer;
     private Light flash;

    
    //switch to shotgun
    [SerializeField] private bool Switchtoshotgun = false;
    
    //every thing for auto fire
    [SerializeField] private bool Switchtoautofire;

    //timer to shoot
    [SerializeField] private float timetowait;
    private float holdtimetowait;

    //shot gun bullet
    public GameObject shotgunbullet;

    [SerializeField] private WeaponStatus weaponStatus;
    private float reloadTimer;


    [SerializeField] GameObject weaponPrefab;
    [SerializeField] GameObject parent;

    private GameObject weapon;
    
    

    

    private void Start()
    {
        weaponStatus = WeaponStatus.ready;
        reloadTimer = 0f;
        holdtimetowait = timetowait;
    }

    void Update()
    {

        //Debug.Log(ammo);
        if (Input.GetKeyDown(KeyCode.R) || XCI.GetButtonDown(XboxButton.X, XboxController.First))
        {
            if (ammo < magSize)
            {
                //StartCoroutine(reloader());
                weaponStatus = WeaponStatus.reloading;
            }
        }


        if(Input.GetKeyDown(KeyCode.I))
        {
            magSize = 10000;
        }

        if (weaponStatus == WeaponStatus.reloading)
        {
            reloadTimer += Time.deltaTime;

            if(reloadTimer >= reloadTime)
            {
                ReloadSystem();
                weaponStatus = WeaponStatus.ready;
            }
        }


        ammotext.text = ammo.ToString();
        magsizetext.text = magSize.ToString();

    }
    
    public void Shoot()
    {
        if(weaponStatus == WeaponStatus.reloading)
        {
            return;
        }

        if (Switchtoshotgun)
        {
            
            ammo = Mathf.Clamp(ammo, 0, 10f);
            if(ammo != 0)
            {   
                shotgun();
            }
        }
        else
        {
            ammo = Mathf.Clamp(ammo, 0, 25f);

            if(ammo != 0)
            {
                if (Switchtoautofire)
                {
                    timetowait -= Time.deltaTime;
                    Shootautofire();
                
                }
                else
                {
                    timetowait -= Time.deltaTime;
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
    }

    public void shotgun()
    {
        timetowait -= Time.deltaTime;
        if(timetowait <= 0)
        {
            
                for (int i = 0; i < 8; i++)
                {
                    Quaternion projectilerotation = Quaternion.Euler(new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0));
                    Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
                }
                ammo--;
                stadesmanger.shootcount();
                timetowait = holdtimetowait;
            
            
        }
    }

    public void Shootautofire()
    {
        
        if(timetowait <= 0)
        {
            
                Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
                ammo--;
                stadesmanger.shootcount();
            
            timetowait = holdtimetowait;
        }
        
    }
    public void SHootSIMIFIRE()
    {
        if (timetowait <= 0)
        {
            
                Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
                ammo--;
                stadesmanger.shootcount();
            
            timetowait = holdtimetowait;
        }
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
    
    //IEnumerator reloader()
    //{
    //    yield return new WaitForSeconds(reloadTime);


    //    for (float i = ammo; i < magSize; i++)
    //    {
    //        if (magSize <= 0) break;
    //        ammo++;
    //        magSize--;
    //    }
    //}
    


}
