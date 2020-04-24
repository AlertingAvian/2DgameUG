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
    public Text buttonText;
    public int buttonLevel;
    public Animator buttonAnimator;
    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        LoadCurrentLevel();
        SetButtonState();

        yourButton.onClick.AddListener(TaskOnClick);
    }

    void LoadCurrentLevel()
    {
        string destination = Application.persistentDataPath + "/controller.dat";
        FileStream file;
        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        int data = (int)bf.Deserialize(file);
        file.Close();
        currentLevel = data;
    }

    void SetButtonState()
    {
        buttonText.text = "Level " + buttonLevel.ToString();
        if (currentLevel > buttonLevel)
        {
            buttonAnimator.SetBool("levelComplete", true);
            buttonAnimator.SetBool("levelLocked", false);
            buttonAnimator.SetBool("currentLevel", false);

            yourButton.interactable = false;
        }
        if (currentLevel < buttonLevel)
        {
            buttonAnimator.SetBool("levelComplete", false);
            buttonAnimator.SetBool("levelLocked", true);
            buttonAnimator.SetBool("currentLevel", false);

            yourButton.interactable = false;
        }
        if (currentLevel == buttonLevel)
        {
            buttonAnimator.SetBool("levelComplete", false);
            buttonAnimator.SetBool("levelLocked", false);
            buttonAnimator.SetBool("currentLevel", true);

            yourButton.interactable = true;
        }
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(buttonLevel+3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
