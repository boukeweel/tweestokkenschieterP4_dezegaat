﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    public GameObject scrap;

    private void Awake()
    {
        instance = this;

        Time.timeScale = 1f;
    }

   
    #endregion

    public GameObject player;

}
                                                                                                                                                                                                                                                                                                                                                                                       