using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatfade : MonoBehaviour {

    public player players;
    
    void Start ()
    {
        Color color = this.GetComponent<MeshRenderer>().material.color;
        color.a = 1f;
        players = FindObjectOfType<player>();
    }
	
	void Update ()
    {
        if (players.splats == true)
       
        {
            Color color = this.GetComponent<MeshRenderer>().material.color;
            color.a -= 0.004f;

            if (color.a >= 0.0f)
            {
                this.GetComponent<MeshRenderer>().material.color = color;
            }
        }
        if (players.splats == false)
        {
            Color color = this.GetComponent<MeshRenderer>().material.color;
            color.a = 1f;

            if (color.a >= 0.0f)
            {
                this.GetComponent<MeshRenderer>().material.color = color;
            }
        }
    }
}
