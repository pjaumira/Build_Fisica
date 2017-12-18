using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class myQuaternion : MonoBehaviour {

    public double X, Y, Z, W;

    public myQuaternion(double w, double x, double y, double z)
    {
        W = w; X = x; Y = y; Z = z;
    }

    public myQuaternion(double w, MyVector3 v)
    {
        W = w; X = v.X; Y = v.Y; Z = v.Z;
    }

    public void FromAxisAngle(Vector3 axis, double angleRadian)
    {
        double m = axis.magnitude;
        if (m > 0.0001)
        {
            double ca = Math.Cos(angleRadian / 2);
            double sa = Math.Sin(angleRadian / 2);
            X = axis.x / m * sa;
            Y = axis.y / m * sa;
            Z = axis.z / m * sa;
            W = ca;
        }
        else
        {
            W = 1; X = 0; Y = 0; Z = 0;
        }
    }
}
