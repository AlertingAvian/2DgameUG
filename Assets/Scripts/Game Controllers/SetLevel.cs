using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    private int sceneIndex; 
    public int level = 0;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        level = sceneIndex - 2;
        Debug.Log(level);
    }

    void SaveControllerFile()
    {
        string destination = Application.persistentDataPath + "/controller.dat";
        FileStream file;
        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        int data = level;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
}
