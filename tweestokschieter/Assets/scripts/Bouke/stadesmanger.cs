using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class stadesmanger : MonoBehaviour
{
    //where the nummer has to come
    [SerializeField]private TMP_Text ShotfiredAmount;
    [SerializeField] private TMP_Text ShotHitAmount;
    [SerializeField] private TMP_Text Acuraty;

    [SerializeField] private TMP_Text Enemyskilled;

    [SerializeField] private TMP_Text DamegesTaken;

    [SerializeField] private TMP_Text Ammopickedupammount;
    [SerializeField] private TMP_Text Healthpickedupammount;
    [SerializeField] private TMP_Text ArmorPickedupAmount;

    [SerializeField] private TMP_Text favotriteweapeon;


    //random int
    public static float shotfired;
    public static float ShotHit;
    private float acuraty;

    public static float EnemysKilled;
    public static float DammageTaken;

    private static int AmmoPickup;
    private static int Healthpickup;
    private static int ArmorPickUp;


    //circle diagram
    private float[] Values;
    public Color[] WedgeColor;
    public Image WedgePrefabes;


    private void Start()
    {
        
        //percentage uitrekkenen
        acuraty = ShotHit * 100 / shotfired;
        //pie diagram

        
        Values = new float[4];
        Values[0] = shotfired;
        Values[1] = ShotHit;
        Values[2] = EnemysKilled;
        Values[3] = DammageTaken;


        MakeCraph();


    }
    //pie diagram
    private void MakeCraph()
    {
        //circle diagram
        float total = 0;
        float zRotation = 0f;
        for (int i = 0; i < Values.Length; i++)
        {
            total += Values[i];
            
        }
        for (int i = 0; i <Values.Length;i++)
        {
            Image Newwedge = Instantiate(WedgePrefabes) as Image;
            Newwedge.transform.SetParent(transform, false);
            Newwedge.color = WedgeColor[i];
            Newwedge.fillAmount = Values[i] / total;
            Newwedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= Newwedge.fillAmount * 360f;
        }
    }
    private void Update()
    {
        //to text
        ShotfiredAmount.text = shotfired.ToString();
        ShotHitAmount.text = ShotHit.ToString();
        Acuraty.text = acuraty.ToString() + ("%"); // string.Format("{0}%", acuraty);

        Enemyskilled.text = EnemysKilled.ToString();
        DamegesTaken.text = DammageTaken.ToString();

        Ammopickedupammount.text = AmmoPickup.ToString();
        Healthpickedupammount.text = Healthpickup.ToString();
        ArmorPickedupAmount.text = ArmorPickUp.ToString();

    }
   
    public void tomainmenu()
    {
        //load scene
        SceneManager.LoadScene(0);
    }
    //alle vairable krijgen
    public static void shothitcount()
    {
        ShotHit++;
    }
    /// <summary>
    /// set enemy kil count
    /// </summary>
    public static void EnemysKilledcount()
    {
        EnemysKilled++;
    }
    /// <summary>
    ///  set Damgas taken count
    /// </summary>
    /// <param name="damegstaken"></param>
    public static void DamgesTakenCount(float damegstaken)
    {
        DammageTaken += damegstaken;
    }
    /// <summary>
    /// set shoot count
    /// </summary>
    public static void shootcount()
    {
        shotfired++;
    }
    /// <summary>
    /// set ammo pickt up ammount
    /// </summary>
    /// <param name="AmmoPickUps"></param>
    public static void AmmoPickUpcount(int AmmoPickUps)
    {
        AmmoPickup += AmmoPickUps;
    }
    /// <summary>
    ///  set health pickup ammount
    /// </summary>
    /// <param name="Healthpickups"></param>
    public static void HealthPickUpcount(int Healthpickups)
    {
        Healthpickup += Healthpickups;
    }
    /// <summary>
    /// set armor pickup ammount 
    /// </summary>
    /// <param name="ArmorPickUps"></param>
    public static void ArmorPickUpcount(int ArmorPickUps)
    {
        ArmorPickUp += ArmorPickUps;
    }
    //nu hebben je alle varibele gekregen
}
