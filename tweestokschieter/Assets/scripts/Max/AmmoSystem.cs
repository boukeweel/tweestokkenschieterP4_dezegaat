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
    [Header("all for ammo")]
    [SerializeField] public float ammo;
    [SerializeField] public float magSize;
    [SerializeField] public float AmmoAlloudInClip;
    [SerializeField] private TextMeshProUGUI ammotext;
    public TextMeshProUGUI magsizetext;

    [Header("bullet")]
    [SerializeField] public GameObject bullet;

    [Header("alle timers")]
    [SerializeField] public float reloadTime = 2;
    public float reloadTimer;
    [SerializeField] public float timetowait;
    private float holdtimetowait;
    public TextMeshProUGUI ReloadTimer;

    [Header("switch to diferent gun")]
    [SerializeField] public bool Switchtoshotgun = false;
    [SerializeField] public  bool Switchtoautofire;

    [Header("enums zijn cool")]
    [SerializeField] private WeaponStatus weaponStatus;

    [Header("De rest")]
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] GameObject parent;
    private GameObject weapon;

    public void Awake()
    {
        weaponStatus = WeaponStatus.ready;
    }
    private void Start()
    {
        
        reloadTimer = 0f;
        holdtimetowait = timetowait;
    }
    public void reload()
    {
        weaponStatus = WeaponStatus.reloading;
        
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


        if (Input.GetKeyDown(KeyCode.I))
        {
            magSize = 10000;
        }

        if (weaponStatus == WeaponStatus.reloading)
        {
            reloadTimer += Time.deltaTime;

            if (reloadTimer >= reloadTime)
            {
                ReloadSystem();
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
        ammo = Mathf.Clamp(ammo, 0, AmmoAlloudInClip);
        if (Switchtoshotgun == true)
        {
            
            
            if(ammo != 0)
            {
                timetowait -= Time.deltaTime;
                if (timetowait <= 0)
                {
                    shotgun();
                }


            }
        }
        else
        {
            

            if(ammo != 0)
            {
                if (Switchtoautofire)
                {
                    timetowait -= Time.deltaTime;
                    if (timetowait <= 0)
                    {
                        Shootautofire();

                    }
                
                }
                else
                {
                    timetowait -= Time.deltaTime;
                    if (timetowait <= 0)
                    {
                        SHootSIMIFIRE();

                    }
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
