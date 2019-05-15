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
    public float shotfired;
    public float RandomShotHIt = 3f;
    private float acuraty;

    public float Randomenemyskilled;
    public float Randomdamgestaken;

    private int RandomAmmoPickedupammount;
    private int RandomHealthpickedupammount;
    private int RandomArmorpickedupAmmount;


    //circle diagram
    private float[] Values;
    public Color[] WedgeColor;
    public Image WedgePrefabes;

    private void Start()
    {
        //randomnummer
        shotfired = Random.Range(0, 60);
        RandomShotHIt = Random.Range(0, 50);
        Randomenemyskilled = Random.Range(0, 10);
        Randomdamgestaken = Random.Range(0, 100);
        RandomAmmoPickedupammount = Random.Range(0, 200); 
        RandomHealthpickedupammount = Random.Range(0, 200);
        RandomArmorpickedupAmmount = Random.Range(0, 200);
        acuraty = RandomShotHIt * 100 / shotfired;
        //pie diagram

        Values = new float[4];
        Values[0] = shotfired;
        Values[1] = RandomShotHIt;
        Values[2] = Randomenemyskilled;
        Values[3] = Randomdamgestaken;


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
        ShotHitAmount.text = RandomShotHIt.ToString();
        Acuraty.text = acuraty.ToString() + ("%");

        Enemyskilled.text = Randomenemyskilled.ToString();
        DamegesTaken.text = Randomdamgestaken.ToString();

        Ammopickedupammount.text = RandomAmmoPickedupammount.ToString();
        Healthpickedupammount.text = RandomHealthpickedupammount.ToString();
        ArmorPickedupAmount.text = RandomArmorpickedupAmmount.ToString();

    }
    public void shootcount()
    {
        shotfired += 1;
    }
    public void tomainmenu()
    {
        //load scene
        SceneManager.LoadScene(0);
    }
}
