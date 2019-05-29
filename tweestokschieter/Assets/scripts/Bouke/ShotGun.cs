using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    
    [SerializeField] private float Speed;
    public int Damages;
    public static int damages;

    private void Start()
    {
        
    }
    public void Update()
    {

        transform.Translate(new Vector3(0, 0, 1) * Speed * Time.deltaTime);
        Destroy(gameObject, 4);
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
