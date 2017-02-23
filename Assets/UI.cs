using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public int lvlForPlayNumber;

    //разделить для каждого меню отдельный скрипт?

	// Use this for initialization
	void Start () {
        //PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MaintMenuBtn()
    {
        Application.LoadLevel("MainMenu");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void LevelsMenuBtn()
    {
        Application.LoadLevel("LevelsMenu");
    }

    public void RepeatLevelBtn()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Resset()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(Application.loadedLevel);
    }
}
