using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : HealthSystem
{
    public int speed;


    public bool Usingcontroler = true;

    private Rigidbody rig;

    public Image FillHealthBar, FillArmorbar;
   /// <summary>
   /// set rigidbody 
   /// </summary>
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// movement
    /// </summary>
    private void FixedUpdate()
    {
        //movement
        rig.MovePosition(transform.position + input() * Time.deltaTime * speed);
        //for using controler
        if (Usingcontroler.Equals(true))
        {
            Vector3 PlayerDirection = Vector3.right * XCI.GetAxisRaw(XboxAxis.RightStickX, XboxController.First) + Vector3.forward * XCI.GetAxisRaw(XboxAxis.RightStickY, XboxController.First);
            if(PlayerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(PlayerDirection, Vector3.up);
            }
        }
        //for using mouse
        if (Usingcontroler.Equals(false))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit _hit;

            if (Physics.Raycast(_ray, out _hit))
            {
                transform.LookAt(_hit.point);

            }
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        //set fillamount of health and armor bar 
        FillHealthBar.fillAmount = (health / 100);
        FillArmorbar.fillAmount = (Armor / 100);

    }

    /// <summary>
    /// set input of movement
    /// </summary>
    /// <returns></returns>
    public Vector3 input()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    /// <summary>
    /// all collisions
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("enemy"))
        {
            
            Health();
        }
        if (collision.collider.CompareTag("HealthPickup"))
        {
            stadesmanger.HealthPickUpcount(10);
            Addhealth(10);
        }
        if (collision.collider.CompareTag("ArmorPickup"))
        {
            stadesmanger.ArmorPickUpcount(20);
            Addarmor(20);
        }
        if(collision.collider.CompareTag("enemyBullet"))
        {
            Health();
        }
        if(collision.collider.CompareTag("lift"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void usingcontrols()
    {
        if (Usingcontroler == true)
        {
            Usingcontroler = false;
        }
        else
        {
            Usingcontroler = true;
        }
    }
    
}
