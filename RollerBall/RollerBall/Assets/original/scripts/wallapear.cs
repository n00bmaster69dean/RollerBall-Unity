using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallapear : MonoBehaviour
{

    public GameObject wall;
    // Use this for initialization
    void Start()
    {
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            // Instantiate(wall, wall.transform.position, Quaternion.identity);
            wall.SetActive(true);

        }
    }
}
