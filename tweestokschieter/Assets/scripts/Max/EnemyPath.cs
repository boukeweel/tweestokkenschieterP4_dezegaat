using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    float t = 1f;
    public AnimationCurve curve;


    void Update()
    {
        transform.position = Vector3.Lerp(points[0].transform.position, points[1].transform.position, curve.Evaluate(t));
        t += Time.deltaTime;
    }


}
