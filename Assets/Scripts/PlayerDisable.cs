using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerDisable : MonoBehaviour
{
    public bool twoPlayer = true;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();
        Debug.Log(twoPlayer);
        player.SetActive(twoPlayer);

    }
    void LoadFile()
    {
        string destination = Application.persistentDataPath + "/settings.dat";
        Debug.Log(destination);
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        bool data = (bool)bf.Deserialize(file);
        Debug.Log(data);
        file.Close();

        twoPlayer = data;

        file.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
