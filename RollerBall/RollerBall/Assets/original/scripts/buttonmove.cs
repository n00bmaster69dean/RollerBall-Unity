using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmove : MonoBehaviour
{
    public levelcontroler levelcontroller;
    public bool buttons = false;
    public GameObject[] wall;
 

    public float currentposx;
    public float currentposy;
    public float currentposz;

    public float newposx;
    public float newposy;
    public float newposz;


    

    // Use this for initialization
    void Start()
    {
       
        levelcontroller = FindObjectOfType<levelcontroler>();
        for (int i = 0; i < wall.Length; i++)
        {

            currentposx = wall[i].transform.position.x;
            currentposy = wall[i].transform.position.y;
            currentposz = wall[i].transform.position.z;
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "player") || (other.gameObject.tag == "player 2"))
        {

            buttons = true;
          //  if (sticks.toggle != true)
            {
                //  wall.SetActive(true);
                for (int i = 0; i < wall.Length; i++)
                {

                    wall[i].transform.position = new Vector3(newposx, newposy, newposz);
                    wall[i].transform.localScale = new Vector3(1.8f, 1.2f, 1.2f);
                }
            }
           // sticks.toggle = false;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "player") || (other.gameObject.tag == "player 2"))
        {
            
            buttons = true;

          //  if (sticks.toggle != true)
            {
                for (int i = 0; i < wall.Length; i++)
                {

                    wall[i].transform.position = new Vector3(currentposx, currentposy, currentposz);
                    wall[i].transform.localScale = new Vector3(5.2f, 1.2f, 1.2f);
                }
            }
        }
    }
}
