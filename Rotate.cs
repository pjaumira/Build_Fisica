﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -5, 0);
        }



        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, 5, 0);
        }

	}
}
