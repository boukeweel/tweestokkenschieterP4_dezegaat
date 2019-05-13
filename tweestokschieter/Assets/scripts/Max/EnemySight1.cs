using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemySight1 : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public float maxAngle;
    public float maxRadius;

    private NavMeshAgent nav;

    public Transform Player;

    private bool isInFov = false;

    [SerializeField] private GameObject[] points;

    [SerializeField] private float Speed;

    [SerializeField] private bool IsPatroling = true;

    int current = 0;
    float WPradius = 1;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 FovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 FovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;


        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, FovLine1);
        Gizmos.DrawRay(transform.position, FovLine2);

        if (!isInFov)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (Player.position - transform.position).normalized * maxRadius);

    }

    public static bool inFov(Transform CheckingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[100];
        int count = Physics.OverlapSphereNonAlloc(CheckingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - CheckingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(CheckingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {
                        Ray ray = new Ray(CheckingObject.position, target.position - CheckingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                            {
                                return true;
                            }
                        }

                    }
                }
            }
        }

        return false;
    }

    private void Update()
    {
        isInFov = inFov(transform, Player, maxAngle, maxRadius);

        if (isInFov == true)
        {
            nav.speed = 5f;
            nav.SetDestination(Player.position);
        }
        if(isInFov == false)
        {
            EnemyPath();
        }

    }

    public void EnemyPath()
    {
        if (Vector3.Distance(points[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= points.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * Speed);
        FaceTarget();
    }

    void FaceTarget()
    {
        Vector3 direction = (points[current].transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


}
