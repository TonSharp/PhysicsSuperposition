using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TensionHelper
{
    public static Vector2 CalculateTensionVector(Dot Target, List<Dot> Dots, float Power, out float Strength)
    {
        Vector2 res = new Vector2();

        foreach(var dot in Dots)
        {
            if(dot == Target) continue;
            else if(!dot.isMain) continue;

            Vector3 Offset = (Target.transform.position - dot.transform.position);
            float strength = ((9*Mathf.Pow(10, 9) * 1)/(Mathf.Pow(Offset.x, 2) + Mathf.Pow(Offset.y, 2))) * Power;

            Vector2 Dir = (Target.transform.position + Offset.normalized*strength);
            res += Dir;
        }

        Strength = res.magnitude;

        return res;
    }


}
