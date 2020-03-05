﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCreate : MonoBehaviour
{

    public bool twoPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();
        SaveFile();
    }

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/settings.dat";
        FileStream file;
        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        bool data = twoPlayer;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    void LoadFile()
    {
        string destination = Application.persistentDataPath + "/settings.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bool data = (bool)bf.Deserialize(file);
        file.Close();

        twoPlayer = data;

        file.Close();
    }
}
