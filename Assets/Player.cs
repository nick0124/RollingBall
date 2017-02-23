using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    //для отладки
    [Range(-1,1)]
    public float x;
    [Range(1, -1)]
    public float z;
    //public Text accelZ;

    //номер следующего уровня, для кнопки перехода на него
    public int nextLevelNumber;

    //скорость шарика
    public float speed;

    //собраные монетки и время
    public Text scoreTxt;
    public Text timeTxt;

    //индикаторы наклона
    public Slider angleHorizontal;
    public Slider angleVertical;

    //количество монеток на уровне
    public int numberOfCoins;

    //меню при конце уровня
    public GameObject endMenu;

    //текущее количество собранных монеток
    int score = 0;

    //текущее время
    float time;

    //игрок
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        scoreTxt.text = "Coins: " + score.ToString() + " of " + numberOfCoins.ToString();
        rb = GetComponent<Rigidbody>();

        Time.timeScale = 1;

        //PlayerPrefs.DeleteAll();
	}
	
    void Update()
    {
        angleHorizontal.value = Input.acceleration.x;
        angleVertical.value = -Input.acceleration.z;
    }

	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float accelerationZ = 0;

        //наклон в отрицательную сторону
        if (-Input.acceleration.z < 0.5f && -Input.acceleration.z > 0)
        {
            accelerationZ = -(0.5f - -Input.acceleration.z);
        }
        //наклон в положительную сторону
        if (-Input.acceleration.z > 0.5f)
        {
            accelerationZ = -Input.acceleration.z - 0.5f;
        }
        //если накланен назад
        if (-Input.acceleration.z < 0)
        {
            accelerationZ = -0.5f;
        }

        //отладка наклона
        //accelZ.text = "Acceleration Z: " + Input.acceleration.z.ToString();

        Vector3 movement = new Vector3(Input.acceleration.x, 0, accelerationZ * 2);

        //Vector3 movementArrows = new Vector3(x, 0, -z-0.5f); для тестов с клавиатуры
        GetComponent<Rigidbody>().AddForce(movement * speed);


        //обновление времени
        time += Time.deltaTime;
        timeTxt.text = "Time: " + System.Math.Round(time,1).ToString();
	}

    void OnTriggerEnter(Collider collision)
    {
        //если столкнулись с монеткой
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            //оюновление счета
            score++;
            scoreTxt.text = "Coins: " + score.ToString() + " of " + numberOfCoins.ToString();

            //если собрали все монетки
            if(score == numberOfCoins)
            {
                //обновляем лучшее время если меньше чем было или равно 0(значит не присвоено)
                if (PlayerPrefs.GetFloat(Application.loadedLevelName + "Time") > time || PlayerPrefs.GetFloat(Application.loadedLevelName + "Time") == 0)
                    PlayerPrefs.SetFloat(Application.loadedLevelName + "Time", time);

                //помечаем уровень как пройденный
                PlayerPrefs.SetInt(Application.loadedLevelName + "Finished", 1);

                //остановка времени и показ победного меню
                Time.timeScale = 0;
                endMenu.SetActive(true);
            }
        }
    }

    //метод для кнопки перехода на следующий уровень
    public void NextLevel()
    {
        Application.LoadLevel("Level" + nextLevelNumber.ToString());
    }
}
