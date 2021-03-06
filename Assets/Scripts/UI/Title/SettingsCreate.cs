﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCreate : MonoBehaviour
{

    public bool twoPlayer = false;
    private int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        SaveSettingsFile();
        CheckControllerFile();
    }

    void SaveSettingsFile()
    {
        string destination = Application.persistentDataPath + "/settings.dat";
        FileStream file;
        if (File.Exists(destination)) return;
        else
        { 
            file = File.Create(destination);
            file.Dispose();
            file = File.OpenWrite(destination);
            bool data = twoPlayer;
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Dispose();
            
        }
        file.Close();

    }

    void CheckControllerFile()
    {
        string destination = Application.persistentDataPath + "/controller.dat";
        FileStream file;
        if (File.Exists(destination)) return;
        else
        {
            file = File.Create(destination);
            file.Dispose();
            file = File.OpenWrite(destination);
            int data = level;
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Dispose();
        }
        file.Close();
    }
}
