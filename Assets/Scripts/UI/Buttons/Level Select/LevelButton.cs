using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

    public Button yourButton;
    public int buttonLevel;
    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        LoadCurrentLevel();
    }

    void LoadCurrentLevel()
    {
        string destination = Application.persistentDataPath + "/controller.dat";
        FileStream file;
        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
            Debug.Log(destination.ToString());
        }
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        int data = (int)bf.Deserialize(file);
        file.Close();
        currentLevel = data;
        Debug.Log(currentLevel.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
