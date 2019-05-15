using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardPickup : MonoBehaviour
{
    public GameObject Keycard;
    public GameObject Keycard2;
    public bool keyCardPickedUp;
    public bool keyCardPickedUp2;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("keycard"))
        {
            keyCardPickedUp = true;
            Destroy(Keycard);
        }
        if(collision.collider.CompareTag("keycard2"))
        {
            keyCardPickedUp2 = true;
            Destroy(Keycard2);
        }
    }
}
