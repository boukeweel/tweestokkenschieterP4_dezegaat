using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public int Damages;
    public static int damages;
    public int timetilldestory;
    

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);

        Destroy(gameObject, timetilldestory);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            damages = Damages;
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
    
}
