using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {

    public int CurrentLevel = 0;
    public static int maxlevel = 3;

    private void OnTriggerEnter(Collider other)
    {
        //if ((other.gameObject.tag == "player") || (other.gameObject.tag == "player 2"))
        //{ 
        //        if (CurrentLevel < maxlevel)
        //        {
        //            CurrentLevel += 1;
        //            Application.LoadLevel(CurrentLevel);
        //        }
        //        else
        //            print("you win");

        //}

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}