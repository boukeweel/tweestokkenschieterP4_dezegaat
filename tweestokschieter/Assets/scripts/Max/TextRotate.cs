using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotate : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        Vector3 targetDir = player.position - transform.position;
          //targetDir *= -1;
        Vector3 newDir = Vector3.RotateTowards(transform.up = new Vector3(0, -1, 0), targetDir, 1f * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);   
    }
}
