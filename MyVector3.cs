using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3
{
    public static implicit operator Vector3(MyVector3 mv)
    {
        return new Vector3(mv.X, mv.Y, mv.Z);
    }

    public static implicit operator MyVector3(Vector3 v)
    {
        return new MyVector3(v.x, v.y, v.z);
    }

    public float X { get; set; }

    public float Y { get; set; }

    public float Z { get; set; }

    public MyVector3()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }

    public MyVector3(float xVal, float yVal, float zVal)
    {
        X = xVal;
        Y = yVal;
        Z = zVal;
    }

    public static MyVector3 operator +(MyVector3 mv1, MyVector3 mv2)
    {
        return new MyVector3(mv1.X + mv2.X, mv1.Y + mv2.Y, mv1.Z + mv2.Z);
    }

    public static MyVector3 operator -(MyVector3 mv1, MyVector3 mv2)
    {
        return new MyVector3(mv1.X - mv2.X, mv1.Y - mv2.Y, mv1.Z - mv2.Z);
    }

    public static MyVector3 operator -(MyVector3 mv1, float var)
    {
        return new MyVector3(mv1.X - var, mv1.Y - var, mv1.Z - var);
    }

    public static MyVector3 operator *(MyVector3 mv1, MyVector3 mv2)
    {
        return new MyVector3(mv1.X * mv2.X, mv1.Y * mv2.Y, mv1.Z * mv2.Z);
    }

    public static MyVector3 operator *(MyVector3 mv, float var)
    {
        return new MyVector3(mv.X * var, mv.Y * var, mv.Z * var);
    }

    public static MyVector3 operator %(MyVector3 mv1, MyVector3 mv2)
    {
        return new MyVector3(mv1.Y * mv2.Z - mv1.Z * mv2.Y,
                             mv1.Z * mv2.X - mv1.X * mv2.Z,
                             mv1.X * mv2.Y - mv1.Y * mv2.X);
    }





    public float DotProduct(MyVector3 mv)
    {
        return X * mv.X + Y * mv.Y + Z * mv.Z;
    }



    public float Magnitude()
    {
        return Mathf.Sqrt(X * X + Y * Y + Z * Z);
    }




    public void Normalize()
    {
        float m = Magnitude();
        if (m > 0)
        {
            X = X / m;
            Y = Y / m;
            Z = Z / m;
        }
        else
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
    }



    public static float Distance(MyVector3 mv1, MyVector3 mv2)
    {
        return (mv1 - mv2).Magnitude();
    }


    public static float DotProduct(MyVector3 mv1, MyVector3 mv2)
    {

        return (mv1.X * mv2.X + mv1.Y * mv2.Y + mv1.Z * mv2.Z);

    }

    public static MyVector3 CrossProduct(MyVector3 mv1, MyVector3 mv2)
    {

        return new MyVector3(mv1.Y * mv2.Z - mv1.Z * mv2.Y, mv1.Z * mv2.X - mv1.X * mv2.Z, mv1.X * mv2.Y - mv1.Y * mv2.X);

    }
}
   
