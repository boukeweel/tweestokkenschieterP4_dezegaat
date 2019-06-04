using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : HealthSystem
{
    public int speed;

    public Animator animator;

    public bool Usingcontroler = true;

    private Rigidbody rig;

    public Image FillHealthBar, FillArmorbar;

    private float damgestaken;

    private bool haveweapeon;

    //flashligt
    [SerializeField] private GameObject flashlight;
    [SerializeField] private float Flashlight_Life;
    private bool Flashlight_on;

    [SerializeField] GameObject hand;
    [SerializeField] AmmoSystem weapon;
    

   /// <summary>
   /// set rigidbody 
   /// </summary>
    private void Start()
    {
        flashlight.SetActive(true);
        rig = GetComponent<Rigidbody>();
        Flashlight_on = true;
       // FillHealthBar.fillAmount = (health / 100);
        //FillArmorbar.fillAmount = (Armor / 100);
        
    }

    /// <summary>
    /// movement
    /// </summary>
    private void FixedUpdate()
    {
        //movement
        rig.MovePosition(transform.position + input() * Time.deltaTime * speed);
        //for using controler
        if (Usingcontroler.Equals(true))
        {
            Vector3 PlayerDirection = Vector3.right * XCI.GetAxisRaw(XboxAxis.RightStickX, XboxController.First) + Vector3.forward * XCI.GetAxisRaw(XboxAxis.RightStickY, XboxController.First);
            if(PlayerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(PlayerDirection, Vector3.up);
            }
        }
        //for using mouse
        if (Usingcontroler.Equals(false))
        {   
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit _hit;

            if (Physics.Raycast(_ray, out _hit))
            {
                transform.LookAt(_hit.point);

            }
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        //set fillamount of health and armor bar
        
       // FillHealthBar.fillAmount = (health / 100);
       // FillArmorbar.fillAmount = (Armor / 100);

        if(Input.GetKeyDown(KeyCode.I))
        {
            health = 10000;
            Armor = 10000;
        }

        //flashlight
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Flashligt();
        }
        if (Flashlight_on.Equals(true))
        {
            Flashlight_Life -= Time.deltaTime;
        }
        if(Flashlight_Life <= 0)
        {
            Flashlight_on = false;
            flashlight.SetActive(false);
            Flashlight_Life = 0;
        }

        if (Input.GetMouseButtonDown(0) || XCI.GetAxis(XboxAxis.RightTrigger, XboxController.First) > 0.1)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) || XCI.GetButtonDown(XboxButton.X, XboxController.First))
        {
            Reload();
        }



    }
    /// <summary>
    /// flashlight turnon
    /// </summary>
    private void Flashligt()
    {
        if (Flashlight_on.Equals(true))
        {
            flashlight.SetActive(false);
            Flashlight_on = false;
        }
        else
        {
            if(Flashlight_Life > 0)
            {
                flashlight.SetActive(true);
                Flashlight_on = true;
            }
            
        }
    }
    /// <summary>
    /// set input of movement
    /// </summary>
    /// <returns></returns>
    public Vector3 input()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    /// <summary>
    /// all collisions
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HealthPickup"))
        {
            stadesmanger.HealthPickUpcount(10);
            Addhealth(10);
        }
        if (collision.collider.CompareTag("ArmorPickup"))
        {
            stadesmanger.ArmorPickUpcount(20);
            Addarmor(20);
        }
        if(collision.collider.CompareTag("enemyBullet"))
        {
            Health(20);
        }
        if(collision.collider.CompareTag("lift"))   
        {
            animator.SetBool("active", true);
            SceneManager.LoadScene("Loading Scene");
        }
    }
    public void usingcontrols()
    {
        if (Usingcontroler == true)
        {
            Usingcontroler = false;
        }
        else
        {
            Usingcontroler = true;
        }
    }
   

    public void SetWeapon(AmmoSystem a)
    {
        weapon = a;
        weapon.SetParent(hand);
        weapon.Awake();
    }

    public void Shoot()
    {
        if(weapon != null)
        {
            weapon.Shoot();
        }
    }
    public void Reload()
    {
        weapon.reload();
    }

}
