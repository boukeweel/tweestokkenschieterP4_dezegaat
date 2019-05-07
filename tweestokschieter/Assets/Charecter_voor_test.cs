using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter_voor_test : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotatespeed = 6.0f;
    public float grafity = 20.0f;

    private Vector3 moveposition = Vector3.zero;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        moveposition = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveposition = transform.TransformDirection(moveposition);
        moveposition *= speed;

        moveposition.y -= grafity * Time.deltaTime;
        controller.Move(moveposition * Time.deltaTime);

    }


}
