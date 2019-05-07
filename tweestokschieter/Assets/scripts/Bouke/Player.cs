using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : HealthSystem
{

    public KeyCode Rechts;
    public KeyCode Down;
    public KeyCode left;
    public KeyCode up;
    public int speed;

    public int healf = 100;
    public int armor = 0;
    
    private void Update()
    {
        if (Input.GetKey(Rechts))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(left))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(up))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(Down))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        
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
