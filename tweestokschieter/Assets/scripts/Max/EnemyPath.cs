using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] float destinationReachedTreshold;
    [SerializeField] private GameObject[] points;
    float t = 0.0f;
    public AnimationCurve curve;
    int current = 0;
    float WPradius = 1;

    public Transform point1;
    public Transform point2;

    public NavMeshAgent nav;
    public NavMeshPath path;

    void Update()
    {
        if(Vector3.Distance(points[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if(current >= points.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * 5f);
        FaceTarget();
    }

    public void Start()
    {
        path = new NavMeshPath();

    }

    void ReachedTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, point2.position);
        if (distanceToTarget < destinationReachedTreshold)
        {
            nav.SetDestination(point1.position);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (points[current].transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
