using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        Destroy(gameObject, 10);
    }
}
