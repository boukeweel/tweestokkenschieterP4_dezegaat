using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : HealthSystem
{

   
    public int speed;

    public int healf = 100;
    public int armor = 0;

    public bool Usingcontroler = true;

    private Rigidbody rig;
   
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
            Debug.Log(PlayerDirection);
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
        


    }
    public Vector3 input()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    
    
    public void Armorpickup()
    {
        armor += 50;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("enemy"))
        {
            Health();
        }
        if (collision.collider.CompareTag("HealthPickup"))
        {
            addhealth(20);
        }
    }
}
