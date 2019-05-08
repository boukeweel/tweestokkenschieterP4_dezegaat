using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardPickup : MonoBehaviour
{
    public GameObject Keycard;
    public bool keyCardPickedUp;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("keycard"))
        {
            keyCardPickedUp = true;
            Destroy(Keycard);
        }
    }
}
