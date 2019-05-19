using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPostition = player.position;
        newPostition.y = transform.position.y;
        transform.position = newPostition;
    }
}
