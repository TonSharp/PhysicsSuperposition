using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotHolder : MonoBehaviour
{
    public List<Dot> Dots;
    public float power;
    private void Update()
    {
        //CalculateFieldStrength();
    }
    public List<Dot> GetMainDots()
    {
        List<Dot> dots = new List<Dot>();

        foreach(var d in Dots)
        {
            if(d.isMain)
                dots.Add(d);
        }

        return dots;
    }
    public void CalculateFieldStrength()
    {
        foreach(var dot in Dots)
        {
            if(dot.isMain) continue;
            dot.GetComponent<LineRenderer>().SetPosition(1, TensionHelper.CalculateTensionVector(dot, Dots, out _));
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
