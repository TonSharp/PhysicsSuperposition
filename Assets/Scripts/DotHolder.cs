using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotHolder : MonoBehaviour
{
    public List<GameObject> Dots;

    public void ChangeActiveStates(GameObject Sender)
    {
        for(int i = 0; i < Dots.Count; i++)
        {
            if(Dots[i] == Sender) continue;
            else Dots[i].GetComponent<Dot>().DisableActive();
        }
    }
}
