using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private void Start()
    {
         Randomshotfired = Random.Range(0, 50);
         RandomShotHIt = Random.Range(0, Randomshotfired);
         Randomenemyskilled = Random.Range(0, 10);
        Randomdamgestaken = Random.Range(0, 100);
        RandomAmmoPickedupammount = Random.Range(0, 200); 
        RandomHealthpickedupammount = Random.Range(0, 200);
        RandomArmorpickedupAmmount = Random.Range(0, 200);

    }
    private void Update()
    {
        //acuraty = (Randomshotfired )
        ShotfiredAmount.text = Randomshotfired.ToString();
        ShotHitAmount.text = RandomShotHIt.ToString();
        Acuraty.text = acuraty.ToString();

        Enemyskilled.text = Randomenemyskilled.ToString();
        DamegesTaken.text = Randomdamgestaken.ToString();

        Ammopickedupammount.text = RandomAmmoPickedupammount.ToString();
        Healthpickedupammount.text = RandomHealthpickedupammount.ToString();
        ArmorPickedupAmount.text = RandomArmorpickedupAmmount.ToString();

    }
}
