using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Player;
    public float range;
    public LayerMask layerMask;
    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Open();
        }

        
    }

    void Open()
    {
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range, layerMask))
        {
            animator.SetBool("active", true);
        }
    }

   
}
