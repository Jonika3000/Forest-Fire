using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts;
using System;

public class SaveManager: MonoBehaviour
{
    public void StartGame()
    {
        if(!PlayerPrefs.HasKey("WorldSeed"))
        {
            PlayerPrefs.SetInt("WorldSeed", new System.Random().Next(0, 30000000));
        }
    }
}
