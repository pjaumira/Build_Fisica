using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


    public float moveSpeed;
    public float speedTarget;
    public bool applyFisicsObject;

    private bool activeSphere, activeCube;

    public Vector3 velocitatInicial;

    public Transform parent;
    public GameObject prefabSphere, prefabCube;
   

    //public GameObject deteccio;
	// Use this for initialization
	void Start () {

        moveSpeed = 1f;
        applyFisicsObject = false;
        activeSphere = true;
        activeCube = false;
        speedTarget = 3f;

        

        

        velocitatInicial = new Vector3(0.8f, 0.1f, 0f);

	}
	
	// Update is called once per frame
	void Update () {

        if (!GetComponent<IK_FABRIK2>().stop)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                this.transform.Translate(0, 0, -5 * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0, 0, 5 * Time.deltaTime);
            }


            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(5 * Time.deltaTime, 0, 0);
            }


            if (Input.GetKey(KeyCode.RightShift))
            {
                this.transform.Translate(0, 5 * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.RightControl))
            {
                this.transform.Translate(0, -5 * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {


                applyFisicsObject = true;
                //this.transform.rotation = Quaternion.LookRotation(velocitatInicial);
                this.transform.Translate(velocitatInicial); 
                
                this.transform.DetachChildren();
                prefabSphere.GetComponent<Rigidbody>().useGravity = true;
                
                
               

            }

        }
        else
        {
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(-5 * Time.deltaTime, 0, 0);
                GetComponent<IK_FABRIK2>().stop = false;
            }
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(-5 * Time.deltaTime, 0, 0);
            GetComponent<IK_FABRIK2>().stop = false;
        }





        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            Instantiate(prefabSphere, parent.transform);
            
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            Instantiate(prefabCube, parent.transform);
            
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
            
        }




    }
}
