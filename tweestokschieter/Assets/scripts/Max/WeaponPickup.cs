using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private GameObject weapons = null;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody gunRigid;
    [SerializeField] private Collider collider;
    [SerializeField] private float range;
    public float maxAngle;
    

    public LayerMask layerMask;

    private bool gunInHand;

    private void Start()
    {
        gunRigid.GetComponent<Rigidbody>();
        collider.GetComponent<Collider>();
    }

    void Update()
    {
        pickUpWeapon();
        //if (gunInHand == false)
        //{
        //    collider.isTrigger = false;
        //}

        //if (gunInHand == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.C))
        //    {
        //        weapons.transform.parent = null;
        //        gunRigid.useGravity = true;    
        //        collider.isTrigger = true;
        //    }
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (collision.collider.CompareTag("pickup"))
            {
                gunInHand = true;
                weapons.transform.position = player.transform.position;
                Quaternion.ToEulerAngles(player.transform.rotation);
                weapons.transform.parent = player;
            }
        }
    }   

    private void pickUpWeapon()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range, layerMask))
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                gunInHand = true;
                weapons.transform.position = player.transform.position;
                Quaternion.ToEulerAngles(player.transform.rotation);
                weapons.transform.parent = player;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 FovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward;

        Gizmos.DrawRay(transform.position, FovLine1 * range);

    }
}
