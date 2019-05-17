using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepvariable 
{
    public static float shotfired;
    public static float shothit;

    public static float Enemyskilled;
    public static float DamagesTaken;

    public static void addshot()
    {
        shotfired++;
        Debug.LogWarning(shotfired);
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
}
