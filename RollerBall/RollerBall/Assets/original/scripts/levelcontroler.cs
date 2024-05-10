using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class levelcontroler : MonoBehaviour {

    public Text coinsleft;

    public GameObject door;
    public GameObject cube;

    public Button play;
    public Button highscore;
    public Button howtoplay;

    public Button back;

    public GameObject playG;
    public GameObject highscoreG;
    public GameObject howtoplayG;

    public GameObject backG;

    public GameObject Highscore1;
    public GameObject Highscore2;
    public GameObject Highscore3;

    public Text highscore1;
    public Text highscore2;
    public Text highscore3;

    public GameObject[] platforms;

    public int coincount=0;
    public int maxcoins;

    public bool sticky;
    public bool still;
    public bool chosen;

    public int random;

    public int Currenthighscore1;
    public int Currenthighscore2;
    public int Currenthighscore3;



    //random = Random.Range(0, platforms.Length);

    //Instantiate(platforms[0], new Vector3(10, 0, 0), Quaternion.identity);

    void Start ()
    {
        // PlayerPrefs.SetInt("Highscore1", 3);
        // PlayerPrefs.SetInt("Highscore2", 2);
        // PlayerPrefs.SetInt("Highscore3", 1);

        Button btn = play.GetComponent<Button>();
        Button btn1 = highscore.GetComponent<Button>();
        Button btn2 = howtoplay.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        btn1.onClick.AddListener(TaskOnClick);
        btn2.onClick.AddListener(TaskOnClick);

        Button btn3 = back.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick);
        chosen = true;
        //cube.SetActive(false);
        // door.SetActive(false);
      
        UpdateUI();
       
    }
	

	void Update ()
    {
        Currenthighscore1 = PlayerPrefs.GetInt("Highscore1");
        highscore1.text = "HighScore1: " + Currenthighscore1;

        if (Input.GetKeyDown("space")) {
            if (chosen == true) { chosen = false; }
           else  if (chosen == false) { chosen = true; }
        }

     
       
    }

    public void savehighscore()
    {
        Currenthighscore1 = PlayerPrefs.GetInt("Highscore1");
        Currenthighscore2 = PlayerPrefs.GetInt("Highscore2");
        Currenthighscore3 = PlayerPrefs.GetInt("Highscore3");
        // set the value in text
        // highscore1.text = "HighScore: " + Currenthighscore1;

        //check if plays score beats the highscore
        if (coincount > Currenthighscore1)
        {

            //if so save the players score in player prefs
            PlayerPrefs.SetInt("Highscore1", coincount);

        }
        else if (coincount > Currenthighscore2)
        { 

            //if so save the players score in player prefs
            PlayerPrefs.SetInt("Highscore2", coincount);

        }
        else if (coincount > Currenthighscore3)
        {
  
            //if so save the players score in player prefs
            PlayerPrefs.SetInt("Highscore3", coincount);

        }
    }

    void TaskOnClick()
    {
        var go = EventSystem.current.currentSelectedGameObject;

        if (go.name == "play")
        {
            SceneManager.LoadScene("scene");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (go.name == "howtoplay")
        {
            SceneManager.LoadScene("tutorial");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (go.name == "highscores")
        {
            

            Debug.Log("You have clicked the button!");
            playG.SetActive(false);
            highscoreG.SetActive(false);
            howtoplayG.SetActive(false);

            Highscore1.SetActive(true);
            Highscore2.SetActive(true);
            Highscore3.SetActive(true);
            backG.SetActive(true);

            Currenthighscore1 = PlayerPrefs.GetInt("Highscore1");
            highscore1.text = "HighScore1: " + Currenthighscore1;

            Currenthighscore2 = PlayerPrefs.GetInt("Highscore2");
            highscore2.text = "HighScore2: " + Currenthighscore2;

            Currenthighscore3 = PlayerPrefs.GetInt("Highscore3");
            highscore3.text = "HighScore3: " + Currenthighscore3;

            // highscore1.text = "";
            // highscore2.text = "";
            // highscore3.text = "";

           
        }
        if (go.name == "Back")
            {
                playG.SetActive(true);
                highscoreG.SetActive(true);
                howtoplayG.SetActive(true);

                Highscore1.SetActive(false);
                Highscore2.SetActive(false);
                Highscore3.SetActive(false);
                backG.SetActive(false);

            }

        if (go.name == "back")
        {
            SceneManager.LoadScene("menu");

        }



    }

    public void UpdateUI()
    {
        if (coincount >= 0)
        {

            coinsleft.text = "coins " + coincount.ToString() + "/" + maxcoins.ToString();
        }
        if (coincount <= 0)
        {
            //            door.SetActive(true);
            //          cube.SetActive(true);
        }
    }
}
