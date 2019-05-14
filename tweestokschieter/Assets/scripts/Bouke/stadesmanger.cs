﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class stadesmanger : MonoBehaviour
{
    [SerializeField]private TMP_Text ShotfiredAmount;
    [SerializeField] private TMP_Text ShotHitAmount;
    [SerializeField] private TMP_Text Acuraty;

    [SerializeField] private TMP_Text Enemyskilled;

    [SerializeField] private TMP_Text DamegesTaken;

    [SerializeField] private TMP_Text Ammopickedupammount;
    [SerializeField] private TMP_Text Healthpickedupammount;
    [SerializeField] private TMP_Text ArmorPickedupAmount;

    [SerializeField] private TMP_Text favotriteweapeon;

    private int Randomshotfired;
    private int RandomShotHIt;
    private int acuraty;

    private int Randomenemyskilled;
    private int Randomdamgestaken;

    private int RandomAmmoPickedupammount;
    private int RandomHealthpickedupammount;
    private int RandomArmorpickedupAmmount;


    //circle diagram
    private int[] Values;
    public Color[] WedgeColor;
    public Image WedgePrefabes;

    private void Start()
    {
         Randomshotfired = Random.Range(0, 50);
         RandomShotHIt = Random.Range(0, Randomshotfired);
         Randomenemyskilled = Random.Range(0, 10);
        Randomdamgestaken = Random.Range(0, 100);
        RandomAmmoPickedupammount = Random.Range(0, 200); 
        RandomHealthpickedupammount = Random.Range(0, 200);
        RandomArmorpickedupAmmount = Random.Range(0, 200);
        acuraty = RandomShotHIt * 100 / Randomshotfired;
        MakeCraph();
        
    }
    private void MakeCraph()
    {
        //Values = int Randomshotfired;
        float total = 0f;
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
        
        ShotfiredAmount.text = Randomshotfired.ToString();
        ShotHitAmount.text = RandomShotHIt.ToString();
        Acuraty.text = acuraty.ToString() + ("%");

        Enemyskilled.text = Randomenemyskilled.ToString();
        DamegesTaken.text = Randomdamgestaken.ToString();

        Ammopickedupammount.text = RandomAmmoPickedupammount.ToString();
        Healthpickedupammount.text = RandomHealthpickedupammount.ToString();
        ArmorPickedupAmount.text = RandomArmorpickedupAmmount.ToString();

    }
    public void tomainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
