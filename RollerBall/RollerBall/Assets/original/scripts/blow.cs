using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blow : MonoBehaviour
{

    public bool left;
    public float push;


    public player players;


    void Start()
    {
        players = FindObjectOfType<player>();
    }


    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
          
            if (left == true)
            {
                players.rb.AddForce(push, 0, 0);
            }
            else { players.rb.AddForce(-push, 0, 0); }

        }
    }
}
