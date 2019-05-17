using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

public class Player : HealthSystem
{

   
    public int speed;

    

    public bool Usingcontroler = true;

    private Rigidbody rig;

    public Image FillHealthBar, FillArmorbar;
   
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rig.MovePosition(transform.position + input() * Time.deltaTime * speed);
        if (Usingcontroler.Equals(true))
        {
            Vector3 PlayerDirection = Vector3.right * XCI.GetAxisRaw(XboxAxis.RightStickX, XboxController.First) + Vector3.forward * XCI.GetAxisRaw(XboxAxis.RightStickY, XboxController.First);
            if(PlayerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(PlayerDirection, Vector3.up);
            }
        }
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

        FillHealthBar.fillAmount = (health / 100);
        FillArmorbar.fillAmount = (Armor / 100);

    }
    public Vector3 input()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("enemy"))
        {
            Health();
        }
        if (collision.collider.CompareTag("HealthPickup"))
        {
            Addhealth(10);
        }
        if (collision.collider.CompareTag("ArmorPickup"))
        {
            Addarmor(20);
        }
        if(collision.collider.CompareTag("enemyBullet"))
        {
            Health();
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
