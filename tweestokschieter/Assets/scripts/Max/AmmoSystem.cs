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

    void Update()
    {
        ammo = Mathf.Clamp(ammo, 0, 25f);

        if(ammo != 0)
        {
            ShootGun();
        }

        Debug.Log(ammo);
        if (Input.GetKeyDown(KeyCode.R) || XCI.GetButtonDown(XboxButton.X, XboxController.First))
        {
            if (ammo < magSize)
            {
                ReloadTimer.text = reloadTime.ToString();
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

    public void ShootGun()
    {
        if (Input.GetMouseButtonDown(0) || XCI.GetButtonDown(XboxButton.RightBumper,XboxController.First))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            ammo--;

        }
    }
    public void AddAmmo(int AmmoAmount)
    {
        magSize += AmmoAmount;
    }

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        reloadTime = countdownValue;
        while (reloadTime > 0)
        {
            Debug.Log("Countdown: " + reloadTime);
            yield return new WaitForSeconds(1.0f);
            reloadTime--;
        }
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
