using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool useConstant;
    public float damage;
    public FloatValue floatValueDamage;

    public float getDamage()
    {
        if (useConstant)
            return damage;
        return floatValueDamage.value;
    }
}
