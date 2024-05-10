using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

    public levelcontroler levelcontroller;

    public Transform target;

    public Transform target2;

    public float smoothspeed;

    private bool i = false;

    public Vector3 offset;

    public Vector3 offset2;

    private void FixedUpdate()
    {

        if (levelcontroller.chosen == true)
        {

            if (i == true) { if (Input.GetKeyDown("i")) { i = false; } }

            else if (Input.GetKeyDown("i")) { i = true; }

            if (i == true)
            {
                Vector3 desiredposition = target.position + offset2;
                Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed);
                transform.position = smoothedposition;

                //transform.LookAt(target);
            }

            if (i == false)
            {

                Vector3 desiredposition = target.position + offset;
                Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed);
                transform.position = smoothedposition;

                //transform.LookAt(target);
            }
        }

        else
        {
            if (i == true) { if (Input.GetKeyDown("i")) { i = false; } }

            else if (Input.GetKeyDown("i")) { i = true; }

            if (i == true)
            {
                Vector3 desiredposition = target.position + offset2;
                Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed);
                transform.position = smoothedposition;

                //transform.LookAt(target);
            }

            if (i == false)
            {

                Vector3 desiredposition = target2.position + offset;
                Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed);
                transform.position = smoothedposition;

                //transform.LookAt(target);
            }
        }
    }



    private void Start()
    {
       
        levelcontroller = FindObjectOfType<levelcontroler>();
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(0.8f);
        {
            //p = true;
        }
    }
}

