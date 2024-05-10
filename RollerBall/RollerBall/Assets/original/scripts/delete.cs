using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    private Transform playerTransform;
    public float Time;
	void Start ()
    {
        
    }
	

	void Update ()
    {
       // if (this.transform.position.z < playerTransform)
		
	}

    IEnumerator mycoroutine()
    {

        yield return new WaitForSeconds(Time);
        {
        Destroy(this.gameObject);
        }
        

    }
}

