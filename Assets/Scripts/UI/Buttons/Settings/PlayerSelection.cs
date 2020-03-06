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

	public Animator playerButton;
	public bool twoPlayer = false;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		SaveFile();
	}

	void Update()
    {
		playerButton.SetBool("twoPlayer", twoPlayer);
    }

	void SaveFile()
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

	void TaskOnClick()
	{
		if (twoPlayer)
        {
			twoPlayer = false;
			txt.text = "One Player";
			Debug.Log("one");
			SaveFile();
        }
		else
        {
			twoPlayer = true;
			txt.text = "Two Player";
			Debug.Log("two");
			SaveFile();
		}
		
		}

}

