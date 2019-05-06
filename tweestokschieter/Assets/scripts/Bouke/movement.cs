using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public KeyCode Rechts;
    public KeyCode Down;
    public KeyCode left;
    public KeyCode up;
    public int speed;
    private void Update()
    {
        if (Input.GetKey(Rechts))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(up))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(Down))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }
}
