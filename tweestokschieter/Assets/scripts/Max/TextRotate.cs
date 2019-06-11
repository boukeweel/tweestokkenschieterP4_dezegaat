using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotate : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetDir = player.position - transform.position;


        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1f * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
