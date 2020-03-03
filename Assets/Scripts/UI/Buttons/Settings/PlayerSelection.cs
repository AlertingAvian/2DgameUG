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
<<<<<<< Updated upstream
	public bool twoPlayer;
	public Image onePlayerSprite;
	public Image twoPlayerSprite;
=======
	public Animator playerButton;
	public bool twoPlayer = false;
>>>>>>> Stashed changes

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
<<<<<<< Updated upstream
		twoPlayer = false;
		twoPlayerSprite = GetComponent<Image>();
		//finish this
=======
		SaveFile();
>>>>>>> Stashed changes
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
		Button btn = yourButton.GetComponent<Button>();
		if (twoPlayer)
        {
			twoPlayer = false;
			txt.text = "One Player";
<<<<<<< Updated upstream
			btn.sprite = oneSprite;
=======
			Debug.Log("one");
>>>>>>> Stashed changes
        }
		else
        {
			twoPlayer = true;
			txt.text = "Two Player";
<<<<<<< Updated upstream
			btn.sprite = twoSprite;
        }
=======
			Debug.Log("two");
		}
		SaveFile();
>>>>>>> Stashed changes
	}
}
