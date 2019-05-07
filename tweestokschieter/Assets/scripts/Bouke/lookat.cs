using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    
    void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(_hit.point);

        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        
    }
}
