using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDot : Dot
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
