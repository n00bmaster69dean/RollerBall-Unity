using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

    public bool buttons = false;
    //public GameObject[] wall;
    public GameObject[] l1;
    public GameObject[] l2;


    public wall[] walls2;



    void Start() {

    }


    void Update() {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        { 

            //makes
            for (int i = 0; i < l2.Length; i++)
            {
                l2[i].gameObject.SetActive(false);

                l2[i].gameObject.SetActive(true);
                for (int e = 0; e < walls2.Length; e++)
                {
                    walls2[e].move = true;
                }
            }

            //removes
            for (int i = 0; i < l1.Length; i++)
            {

                l1[i].gameObject.SetActive(false);
            }

        }
    }
}
   