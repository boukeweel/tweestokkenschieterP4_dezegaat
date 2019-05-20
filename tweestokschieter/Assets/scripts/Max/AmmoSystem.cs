﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using XboxCtrlrInput;



public class AmmoSystem : MonoBehaviour
{
    [SerializeField]private float ammo;
    [SerializeField] private float magSize;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reloadTime;
    [SerializeField] private TextMeshProUGUI ammotext;
    public TextMeshProUGUI magsizetext;
    public TextMeshProUGUI ReloadTimer;
    //switch to shotgun
    [SerializeField] private bool Switchtoshotgun = false;
    
    //every thing for auto fire
    [SerializeField] private bool Switchtoautofire;
    //timer to shoot
    [SerializeField] private float timetowait;
    private float holdtimetowait;




    private void Start()
    {
        holdtimetowait = timetowait;
    }
    void Update()
    {
        if (Switchtoshotgun)
        {
            ammo = Mathf.Clamp(ammo, 0, 10);
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
                    SHootSIMIFIRE();
                }
            
             }

        }
        

        //Debug.Log(ammo);
        if (Input.GetKeyDown(KeyCode.R) || XCI.GetButtonDown(XboxButton.X, XboxController.First))
        {
            if (ammo < magSize)
            {
                StartCoroutine(reloader());
            }
        }


        ammotext.text = ammo.ToString();
        magsizetext.text = magSize.ToString();

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
        if(timetowait <= 0)
        {
            if(Input.GetMouseButtonDown(0) || XCI.GetButtonDown(XboxButton.RightBumper, XboxController.First))
            {
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(bullet, transform.position - (transform.forward), transform.rotation);
                }
                ammo--;
                stadesmanger.shootcount();
            }
        }
    }
    public void Shootautofire()
    {
        
        if(timetowait <= 0)
        {
            if (Input.GetMouseButton(0) || XCI.GetButton(XboxButton.RightBumper, XboxController.First))
            {
                Instantiate(bullet, transform.position - (transform.forward), transform.rotation);
                ammo--;
                stadesmanger.shootcount();
            }
            timetowait = holdtimetowait;
        }
        
    }
    public void SHootSIMIFIRE()
    {
        if (Input.GetMouseButtonDown(0) || XCI.GetButtonDown(XboxButton.RightBumper,XboxController.First))
        {
            Instantiate(bullet, transform.position - (transform.forward), transform.rotation);
            ammo--;
            stadesmanger.shootcount();
        }
    }
    public void AddAmmo(int AmmoAmount)
    {
        magSize += AmmoAmount;
    }
    


    IEnumerator reloader()
    {
        yield return new WaitForSeconds(reloadTime);


        for (float i = ammo; i < magSize; i++)
        {
            if (magSize <= 0) break;
            ammo++;
            magSize--;
        }
    }

}
