using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReference
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatValue Variable;

    public FloatReference() { }

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.value; }
    }

    //public static implicit operator float(FloatValue reference)
    //{
    //    return (float) reference.value;
    //}
}
