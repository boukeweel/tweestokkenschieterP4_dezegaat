using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lift : MonoBehaviour
{
    public int level_To_Go_to;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(level_To_Go_to);
        }
    }
}
