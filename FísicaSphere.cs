using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FísicaSphere : MonoBehaviour {


    float gravity = -0.8f;
    public float massSphere;
    private Movement target;

	// Use this for initialization
	void Start () {

        massSphere = 1f;
        target = gameObject.AddComponent<Movement>();

    }
	
	// Update is called once per frame
	void Update () {

        //if (target.applyFisicsObject)
        //{

        //    Debug.Log("hola");
        //   // this.transform.Translate(0, gravity * massSphere, 0);

        //}




    }
}
