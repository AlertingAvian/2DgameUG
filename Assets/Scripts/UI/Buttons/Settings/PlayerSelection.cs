using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerSelection : MonoBehaviour
{
	public Button yourButton;
	public Text txt;
	public bool twoPlayer = false;
	public Animator playerButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		if (twoPlayer)
        {
			twoPlayer = false;
			txt.text = "One Player";
			playerButton.SetBool("twoPlayer",true);
        }
		else
        {
			twoPlayer = true;
			txt.text = "Two Player";
			playerButton.SetBool("twoPlayer", false);
		}
	}
}
