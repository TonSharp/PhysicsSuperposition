using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotHolder : MonoBehaviour
{
    public List<GameObject> Dots;
    public float power;

    private void Update()
    {
        CalculateFieldStrength();
    }
    public Dot GetMainDot()
    {
        foreach(var d in Dots)
        {
            if(d.GetComponent<Dot>().isMain)
            return d.GetComponent<Dot>();
        }

        return null;
    }
    public void CalculateFieldStrength()
    {
        Dot mainDot = GetMainDot();
        if(mainDot == null ) return;

        foreach(var dot in Dots)
        {
            if(dot != mainDot.gameObject)
            {
                Vector3 offsetPos = dot.transform.position - mainDot.transform.position;
                
                float strength = ((9*Mathf.Pow(10, 9) * 1)/(Mathf.Pow(offsetPos.x, 2) + Mathf.Pow(offsetPos.y, 2))) * power;
                float maxOffset = Mathf.Max(Mathf.Abs(offsetPos[0]), Mathf.Abs(offsetPos[1]));

                Vector3 lineDir = (dot.transform.position + offsetPos.normalized*strength);//*strength;

                dot.GetComponent<LineRenderer>().SetPosition(1, new Vector3(lineDir.x, lineDir.y, 0));
            }
        }
    }
    public void ChangeActiveStates(GameObject Sender)
    {
        for(int i = 0; i < Dots.Count; i++)
        {
            if(Dots[i] == Sender) continue;
            else Dots[i].GetComponent<Dot>().DisableActive();
        }
    }
}
