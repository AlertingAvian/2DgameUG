using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSelection : MonoBehaviour
{
	public Button yourButton;
	public Text txt;
	public bool twoPlayer;
	public Image onePlayerSprite;
	public Image twoPlayerSprite;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		twoPlayer = false;
		twoPlayerSprite = GetComponent<Image>();
		//finish this
	}

	void TaskOnClick()
	{
		Button btn = yourButton.GetComponent<Button>();
		if (twoPlayer)
        {
			twoPlayer = false;
			txt.text = "One Player";
			btn.sprite = oneSprite;
        }
		else
        {
			twoPlayer = true;
			txt.text = "Two Player";
			btn.sprite = twoSprite;
        }
	}
}
