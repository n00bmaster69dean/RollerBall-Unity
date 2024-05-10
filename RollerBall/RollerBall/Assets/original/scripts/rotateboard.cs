using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateboard : MonoBehaviour {

	public float pos=0;
	
	void Start () {
		
	}
	
	
	void Update () {

        if (Input.GetKey ("left")) 
		{
			
			transform.Rotate (new Vector3 (0, 0, 40) * Time.deltaTime,Space.World);
			pos = transform.rotation.z;
            
            pos = pos * -60;
		}

		if (Input.GetKey ("right")) 
		{
			transform.Rotate(new Vector3 (0, 0, -40)* Time.deltaTime, Space.World);
		    pos = transform.rotation.z;
           
            pos = pos * -60;
		}
      //  pos = pos * 1.0125f;

	}
}
