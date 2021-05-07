using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TensionHelper
{
    private static SettingsHandler settingsHandler = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();
    public static float MaxLength = 2.5f;
    public static Vector2 CalculateTensionVector(Dot Target, List<Dot> Dots, out float Strength)
    {
        Vector2 res = new Vector2();
        
            Vector3 Dir = new Vector3();

        foreach(var dot in Dots)
        {
            if(dot == Target) continue;
            else if(!dot.isMain) 
                continue;

            Vector3 Offset = (Target.transform.position - dot.transform.position);
            float strength = ((9*Mathf.Pow(10, 9) * 1)/(Mathf.Pow(Offset.x, 2) + Mathf.Pow(Offset.y, 2))) * settingsHandler.Power;

            if(!dot.isProton)
                Dir += Offset.normalized * strength;

            else
                Dir -= Offset.normalized * strength;
        }

        Strength = Dir.magnitude; //Change

        if(!settingsHandler.IsSameLength){
            float length = Dir.magnitude;
            if(length > MaxLength)
            Dir = Dir.normalized * settingsHandler.MaxLength;
        }
        else 
            Dir = Dir.normalized * settingsHandler.MaxLength;
        res = new Vector2(Dir.x, Dir.y);
        res += new Vector2(Target.transform.position.x, Target.transform.position.y);

        return res;
    }

}
