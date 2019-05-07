using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : HealthSystem
{

    
    public int speed;

    public int healf = 100;
    public int armor = 0;

    public Rigidbody rig;
    
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {


        rig.MovePosition(transform.position + input() * Time.deltaTime * speed);



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
}
