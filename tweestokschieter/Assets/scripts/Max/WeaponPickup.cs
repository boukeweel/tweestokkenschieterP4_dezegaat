using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private GameObject weapons;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody gunRigid;
    [SerializeField] private Collider collider;
    [SerializeField] private float range;
    public float maxAngle;
    
    public LayerMask layerMask;

    private bool gunInHand;

 

    void Update()
    {
        pickUpWeapon();
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        if (collision.collider.CompareTag("pickup"))
    //        {
    //            gunInHand = true;
    //            weapons.transform.position = player.transform.position;
    //            Quaternion.ToEulerAngles(player.transform.rotation);
    //            weapons.transform.parent = player;
    //        }
    //    }
    //}   

    private void pickUpWeapon()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range, layerMask))
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                weapons.transform.parent = player.transform;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 FovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward;

        Gizmos.DrawRay(transform.position, FovLine1 * range);

    }
=======
    private float PickUpRange = 2f;
    
>>>>>>> master
}
