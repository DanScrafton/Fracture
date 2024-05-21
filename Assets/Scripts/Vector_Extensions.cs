using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector_Extensions 
{
    public static bool Is_Real(this float f)
    {
        return !float.IsInfinity(f) && !float.IsNaN(f);
    }

    public static bool Is_Real(this Vector2 v2)
    {
        return v2.x.Is_Real() && v2.y.Is_Real();
    }

    public static bool Is_Real(this Vector3 v3)
    {
        return v3.x.Is_Real() && v3.y.Is_Real() && v3.z.Is_Real();
    }


}
