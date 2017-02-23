using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour {

    public bool open = false;
    public int levelNumber;
    public Text bestTimeTxt;
    //public GameObject openImage;
    int finished;
    public GameObject closedImage;
    Button button;

	// Use this for initialization
	void Start () {
        UpdateBestTime();
        Openlevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel()
    {
        //если уровень открыт то его можно загрузить
        if (open == true)
            Application.LoadLevel("Level" + levelNumber.ToString());
    }

    void UpdateBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("Level" + levelNumber.ToString() + "Time");
        bestTimeTxt.text = "Best time: " + System.Math.Round(bestTime, 1);
    }

    /*
    void UpdateStatus()
    {
        //если уровень открыт, убирается значек замочка
        int finished = PlayerPrefs.GetInt("Level" + levelNumber.ToString() + "Finished");
        if(finished==1)
        {
            openImage.SetActive(true);
            closedImage.SetActive(false);
        }
        if (finished == 0)
        {
            openImage.SetActive(false);
            closedImage.SetActive(true);
        }
    }
     */

    void Openlevel()
    {
        //если это не первый уровень(потому что первый уровень всегда открыт)
        if (levelNumber != 1)
        {
            //если предыдущий уровень пройден то этот уровень открывается и убирается замочек
            if (PlayerPrefs.GetInt("Level" + (levelNumber - 1).ToString() + "Finished") == 1)
            {
                open = true;
                closedImage.SetActive(false);
            }
        }
        else
            closedImage.SetActive(false);
    }
}
