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
    [SerializeField] public TextMeshProUGUI ammotext;
    public TextMeshProUGUI magsizetext;

    [Header("bullet")]
    [SerializeField] public GameObject bullet;

    [Header("alle timers")]
    [SerializeField] public float reloadTime = 2;
    public float reloadTimer;
    [SerializeField] public float timetowait;
    private float holdtimetowait = 0.5f;
    public TextMeshProUGUI ReloadTimer_;

    [Header("switch to diferent gun")]
    [SerializeField] public bool Switchtoshotgun = false;
    [SerializeField] public  bool Switchtoautofire;

    [Header("enums zijn cool")]
    [SerializeField] public WeaponStatus weaponStatus;

    [Header("De rest")]
    [SerializeField] public GameObject weaponPrefab;
    [SerializeField] public GameObject parent;
    public GameObject weapon;
    [SerializeField] weapen Weapon;

    public void Awake()
    {
        weaponStatus = WeaponStatus.ready;
    }
    public void AddAmmo(int AmmoAmount)
    {
        magSize += AmmoAmount;
        Weapon.setallfabriale();
    }
    public void UpgradeClip()
    {
        AmmoAlloudInClip += 10;
        Weapon.setallfabriale();
    }
    public void upgradeRelaodtimer()
    {
        reloadTime -= 0.2f;
        Weapon.setallfabriale();
    }
    public void Upgradetimetowait()
    {
        holdtimetowait -= 0.02f;
        Weapon.setallfabriale();
    }
    public void UpgradeToShutgun()
    {
        Weapon.firetype = weaponfiretype.shotgun;
        Weapon.setallfabriale();
    }
    public void UpgradeToAutofire()
    {
        Weapon.firetype = weaponfiretype.autofire;
        Weapon.setallfabriale();
    }
    public void UpradeToSimifire()
    {
        Weapon.firetype = weaponfiretype.simifire;
        Weapon.setallfabriale();
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
