using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class items : MonoBehaviour
{
    //[SerializeField] private GameObject partical;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //partical.SetActive(true);

            Destroy(gameObject);
        }
    }
}
