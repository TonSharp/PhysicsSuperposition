using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPanel : MonoBehaviour
{
    public GameObject parent;

    public void SetValue(bool val)
    {
        parent.GetComponent<Dot>().SetMainValue(val);
    }
}
