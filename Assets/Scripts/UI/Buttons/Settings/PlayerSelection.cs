using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;



public class PlayerSelection : MonoBehaviour
{
	public Button yourButton;
	public Text txt;
	public Animator playersButton;
	public bool twoPlayer = false;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        LoadFile();
		SaveFile();
    }

	void Update()
    {
		playersButton.SetBool("twoPlayer", !twoPlayer);
        if (twoPlayer)
        {
            txt.text = "Two Player";
        }
        else
        {
            txt.text = "One Player";
        }
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

    public void TaskOnClick()
    {
        if (twoPlayer)
        {
            twoPlayer = false;
            txt.text = "One Player";
        }
        else
        {
            twoPlayer = true;
            txt.text = "Two Player";
        }
        SaveFile();
    }
     
}
