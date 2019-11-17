using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperMethods
{
    public static float Map (float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public static float CalculateAngle(Vector3 first, Vector3 second)
    {
        return Mathf.Atan2(first.y-second.y, first.x-second.x)*180 / Mathf.PI;
    }

    public static float PositiveAngle(float angle)
    {
        if(angle < 0)
        {
            return 360 + angle;
        }else
        {
            return angle;
        }
    }
}
