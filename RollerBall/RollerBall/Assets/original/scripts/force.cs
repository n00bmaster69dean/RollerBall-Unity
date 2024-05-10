using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour {

	void Start () {
		
	}
	

	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

        }
    }
}
