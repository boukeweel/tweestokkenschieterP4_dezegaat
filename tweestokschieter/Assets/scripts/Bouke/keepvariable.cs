using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepvariable 
{

    
    public static float shotfired;
    public static float shothit;

    public static float Enemyskilled;
    public static float DamagesTaken;

    public static int AmmoPickUp;
    public static int HealthPickUp;
    public static int ArmorPickUp;
    
    //alles er bij optellen
    public static void addshot()
    {
        shotfired++;
        
        
    }
    public static void addhit()
    {
        shothit++;
    }
    public static  void addenemykilled()
    {
        Enemyskilled++;
    }
    public static void AddDamegstaken()
    {
        DamagesTaken++;
    }
    public static void AmmoPickUP(int ammopicktup)
    {
        AmmoPickUp = ammopicktup;
    }
    public static void healthPickUp(int healthpickup)
    {
        HealthPickUp = healthpickup;
    }
    public static void ArmorPickUP(int armorpickup)
    {
        ArmorPickUp = armorpickup;
    }
    // alles terug sturen naar stadesmanger
    public static void geefallesdoor()
    {
        stadesmanger.shootcount(shotfired);
        stadesmanger.shothitcount(shothit);
        stadesmanger.DamgesTakenCount(DamagesTaken);
        stadesmanger.EnemysKilledcount(Enemyskilled);
        stadesmanger.AmmoPickUpcount(AmmoPickUp);
        stadesmanger.HealthPickUpcount(HealthPickUp);
        stadesmanger.ArmorPickUpcount(ArmorPickUp);

    }
    
}
