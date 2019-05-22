using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using XboxCtrlrInput;



public class AmmoSystem : MonoBehaviour
{
    [SerializeField] private float ammo;
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
    //shot gun bullet
    public GameObject shotgunbullet;

    private void Start()
    {
        holdtimetowait = timetowait;
    }

    void Update()
    {
        
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

        if(Input.GetKeyDown(KeyCode.I))
        {
            magSize = 10000;
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
        timetowait -= Time.deltaTime;
        if(timetowait <= 0)
        {
            if (Input.GetMouseButtonDown(0) || XCI.GetAxis(XboxAxis.RightTrigger, XboxController.First) > 0.1f)
            {
                for (int i = 0; i < 8; i++)
                {
                    Quaternion projectilerotation = Quaternion.Euler(new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0));
                    Instantiate(bullet, transform.position, transform.rotation);
                }
                ammo--;
                stadesmanger.shootcount();
                timetowait = holdtimetowait;
            }
            
        }
    }

    public void Shootautofire()
    {
        
        if(timetowait <= 0)
        {
            if (Input.GetMouseButton(0) || XCI.GetAxis(XboxAxis.RightTrigger, XboxController.First) > 0.1f)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                ammo--;
                stadesmanger.shootcount();
            }
            timetowait = holdtimetowait;
        }
        
    }
    public void SHootSIMIFIRE()
    {
        if (Input.GetMouseButtonDown(0) || XCI.GetAxis(XboxAxis.RightTrigger, XboxController.First) > 0.1f)
        {
            Instantiate(bullet, transform.position, transform.rotation);
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
