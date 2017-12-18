using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IK_FABRIK2 : MonoBehaviour
{


    public GameObject terra;
    public float diferencia;
    public float novaDiferencia;
    public bool stop;
    //private Vector3 oldPosition, newPosition;
    private MyVector3 oldPosition, newPosition;

    public Transform[] joints;
    public Transform target;

    private Vector3[] copy;
    private float[] distances;
    private bool done;

    public float maxIterations = 10;

    public float treshold_condition = 0.01f;

    void Start()
    {
        distances = new float[joints.Length - 1];
        copy = new Vector3[joints.Length];
        

        //diferencia = Vector3.Distance(target.transform.position, terra.transform.position);
        diferencia = MyVector3.Distance(target.transform.position, terra.transform.position);
        
        stop = false;

        oldPosition = target.transform.position;
    }

    void Update()
    {
        // 1.Copy the joints positions to work with. 
        //Calculate also the distances between joints
        //TODO1
        //Debug.Log(joints[3].transform.position.x);
        newPosition = target.transform.position;

        //novaDiferencia = Vector3.Distance(target.transform.position, terra.transform.position);
        novaDiferencia = MyVector3.Distance(target.transform.position, terra.transform.position);
        if (novaDiferencia > diferencia)
        {

            novaDiferencia = diferencia;
            stop = true;
        }
        else
        {
            stop = false;
        }

        copy[0] = joints[0].position;
        for (int i = 0; i < copy.Length - 1; i++)
        {
            copy[i + 1] = joints[i + 1].position;
            //distances[i] = Vector3.Distance(copy[i + 1], copy[i]);
            distances[i] = MyVector3.Distance(copy[i + 1], copy[i]);
        }


        //done = TODO2
        done = (copy[copy.Length - 1] - target.position).magnitude < treshold_condition;
        if (!done)
        {
            //float targetRootDist = Vector3.Distance(copy[0], target.position);
            float targetRootDist = MyVector3.Distance(copy[0], target.position);

            // Update joint positions
            if (targetRootDist > distances.Sum())
            {
                // The target is unreachable
                //TODO3

                for (int i = 0; i < copy.Length - 1; i++)
                {
                    //float r = Vector3.Distance(target.position, copy[i]);
                    float r = MyVector3.Distance(target.position, copy[i]);
                    float lambda = distances[i] / r;
                    copy[i + 1] = (1 - lambda) * copy[i] + (lambda * target.position);

                }


            }
            else
            {
                //float comvulguis = Vector3.Distance(target.position, copy[copy.Length - 1]);
                float comvulguis = MyVector3.Distance(target.position, copy[copy.Length - 1]);

                //Vector3 b = copy[0];
                MyVector3 b = copy[0];

                int iter = 0;
                // The target is reachable
                while (comvulguis > treshold_condition && iter < maxIterations)
                {


                    iter++;
                    // STAGE 1: FORWARD REACHING
                    //TODO

                    //Debug.Log("FABRIK iteration:" + iter);
                    copy[copy.Length - 1] = target.position;
                    for (int i = copy.Length - 2; i > 0; i--)
                    {
                        //float r = Vector3.Distance(copy[i + 1], copy[i]);
                        float r = MyVector3.Distance(copy[i + 1], copy[i]);
                        float lambda = distances[i] / r;
                        copy[i] = (1 - lambda) * copy[i + 1] + (lambda * copy[i]);


                    }
                    // STAGE 2: BACKWARD REACHING
                    //TODO
                    copy[0] = b;
                    for (int i = 0; i < copy.Length - 1; i++)
                    {
                        //float r = Vector3.Distance(copy[i + 1], copy[i]);
                        float r = MyVector3.Distance(copy[i + 1], copy[i]);
                        float lambda = distances[i] / r;
                        copy[i + 1] = (1 - lambda) * copy[i] + (lambda * copy[i + 1]);

                    }

                    //comvulguis = Vector3.Distance(copy[copy.Length - 1], target.position);
                    comvulguis = MyVector3.Distance(copy[copy.Length - 1], target.position);


                }
            }

            // Update original joint rotations
            for (int i = 0; i <= joints.Length - 2; i++)
            {
                //TODO4 
                //without rotations of the different pieces:
                //joints[i + 1].position = copy[i + 1];
                //with rotations of the different pieces:

                //Vector3 init = joints[i + 1].position - joints[i].position;
                //Vector3 now = copy[i + 1] - copy[i];

                MyVector3 init = joints[i + 1].position - joints[i].position;
                MyVector3 now = copy[i + 1] - copy[i];

                init.Normalize();
                now.Normalize();

                //float angle = Mathf.Acos(Vector3.Dot(init.normalized, now.normalized)) * Mathf.Rad2Deg;
                float cosa = Vector3.Dot(init, now);
                float sina = Vector3.Cross(init, now).magnitude;

                //init.Normalize();
                //now.Normalize();

                //float cosa = MyVector3.DotProduct(init, now);
                //float sina = MyVector3.CrossProduct(init, now).SquareMagnitude;

                float angle = Mathf.Atan2(sina, cosa) * Mathf.Rad2Deg;


                MyVector3 axis = Vector3.Cross(init, now).normalized;
                joints[i].rotation = Quaternion.AngleAxis(angle, axis) * joints[i].rotation;
                joints[i + 1].position = copy[i + 1];

            }
        }

        
    }

}