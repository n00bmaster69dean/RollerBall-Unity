using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastTest : MonoBehaviour
{
    LineRenderer line;
    public Text infotext;

    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = true; //makes the ray visible
        line.startWidth = 0.4f; // start siaze
        line.endWidth = 0.1f; // end size
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; // what is hit by the beam
        float raylength = 54; // how far away the ray goes

      //  if (!line.enabled) return;
        Ray ray = new Ray(transform.position, transform.forward); // draws ray

        line.SetPosition(0, ray.origin); // start at start point
        line.SetPosition(1, ray.GetPoint(raylength)); // end point

        if (Physics.Raycast(ray, out hit, raylength)) // test for collision
        {
            line.SetPosition(1, hit.point); // stop at the other gameobjects position

            infotext.text = "Hit object: " + hit.collider.name + " at world space " + hit.point.ToString() + "\n"; // writes to text

            if (hit.rigidbody) // other has rigidbody
                infotext.text += "It's a rigid body";
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(raylength));
            infotext.text = "Hit object: nothing";
        }

    }
}
