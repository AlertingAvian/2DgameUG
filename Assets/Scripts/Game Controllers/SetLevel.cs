using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    public int sceneIndex = SceneManager.GetActiveIndex().buildIndex;
    public int level = 0;

    void Start()
    {
        level = sceneIndex - 2;
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
