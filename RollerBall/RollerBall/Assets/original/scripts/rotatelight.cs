﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatelight : MonoBehaviour
{

    public float pos = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        

    }
}
