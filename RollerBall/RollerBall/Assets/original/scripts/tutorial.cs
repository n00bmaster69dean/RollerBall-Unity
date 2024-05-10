using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour {

    public Text text;

    void Start ()
    {
        StartCoroutine(mycoroutine());
    }


	void Update ()
    {
		
	}

    IEnumerator mycoroutine()
    {
        yield return new WaitForSeconds(0f);
        {
            text.text = "Welcome to the tutorial ";
        }

        yield return new WaitForSeconds(2f);
        {
            text.text = "Use the left and right \n"  +
                "keys to move the board ";
        }

        yield return new WaitForSeconds(3f);
        {
            text.text = "Avoid the blocks ";
        }

        yield return new WaitForSeconds(3f);
        {
            text.text = "Collect the coins ";
        }

        yield return new WaitForSeconds(2f);
        {
            text.text = "Collect power ups to help you ";
        }

        yield return new WaitForSeconds(3f);
        {
            text.text = "<- Go to the next platform to Finish ";
        }




        // powerup.text = "Speed Up! ";//+ coincount.ToString() + "/" + maxcoins.ToString();


    }
    }
