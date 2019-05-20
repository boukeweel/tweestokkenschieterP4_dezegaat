using System.Collections;
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
    [SerializeField] private bool Switchtoautofire;
    //auto fire 
    [SerializeField] private float timetowait;
    private float holdtimetowait;




    private void Start()
    {
        holdtimetowait = timetowait;
    }
    void Update()
    {
        ammo = Mathf.Clamp(ammo, 0, 25f);

        if(ammo != 0)
        {
            if (Switchtoautofire)
            {
                SHootSIMIFIRE();
            }
            else
            {
                timetowait -= Time.deltaTime;
                Shootautofire();
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
