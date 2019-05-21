using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private float Speed;
    private float Randomupordown;
    private float Randomleftorright;

    private void Start()
    {
        Randomleftorright = Random.Range(-3, 3);
        Randomupordown = Random.Range(-3, 3);
    }
    public void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Speed * Time.deltaTime);
        
    }
}
