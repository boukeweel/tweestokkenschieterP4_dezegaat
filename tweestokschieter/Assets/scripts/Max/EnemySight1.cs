using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemySight1 : HealthSystem
{
    public float fieldOfViewAngle = 110f;
    public float maxAngle;
    public float maxRadius;
    public float waitTilnextFire;
    private bool Timer = true;
    public float fireSpeed;

    private NavMeshAgent nav;

    public Transform Player;

    private bool isInFov = false;

    [SerializeField] private Transform[] points;

    [SerializeField] private float Speed;

    [SerializeField] private bool IsPatroling = true;

    [SerializeField] private GameObject bullet;

    int current = 0;
    float WPradius = 1;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        waitTilnextFire = Time.time;
    }

    /// <summary>
    /// laat de angle en radisu zien van de enemy in de scene 
    /// </summary>
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

    /// <summary>
    /// checked of the speler in the field of view van de enemy is
    /// </summary>
    /// <param name="CheckingObject"></param>
    /// <param name="target"></param>
    /// <param name="maxAngle"></param>
    /// <param name="maxRadius"></param>
    /// <returns></returns>
    public static bool inFov(Transform CheckingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[150];
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

        if (isInFov == true || takingDamage > 0)
        {
            FacePlayer();
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * Speed);
            shoot();
        }

        if (isInFov == false)
        {
            Speed = 1f;
            EnemyPath();
            FaceTarget();
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
    }

    void FaceTarget()
    {
            Vector3 direction = (points[current].transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = lookRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void FacePlayer()
    {
        transform.LookAt(Player);
    }

    void shoot()
    {
         if(Time.time > waitTilnextFire)
         {
            Instantiate(bullet, transform.position + (transform.forward), transform.rotation);
            waitTilnextFire = Time.time + fireSpeed;
         }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            stadesmanger.shothitcount();
            EnemyHealth(Bullet.damages);
        }
    
    }

  

}
