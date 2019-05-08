using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : HealthSystem
{

   
    public int speed;

    public int healf = 100;
    public int armor = 0;

    private Rigidbody rig;
    float timer_test = 0.1f;
    int ding = 1;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {


        rig.MovePosition(transform.position + input() * Time.deltaTime * speed);

        Vector3 PlayerDirection = Vector3.right * XCI.GetAxisRaw(XboxAxis.RightStickX, XboxController.First) + Vector3.forward * XCI.GetAxisRaw(XboxAxis.RightStickY, XboxController.First);
        if(PlayerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(PlayerDirection, Vector3.up);
        }
        Debug.Log(PlayerDirection);


    }
    public Vector3 input()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    
    public void Gedamegs()
    {
            if(armor > 0)
            {
                armor -= 10;
            }
            else if (healf > 0)
            {
                healf -= 10;
            }
            else if (healf <= 0)
            {
                print("dood");
            }
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
    }
}
