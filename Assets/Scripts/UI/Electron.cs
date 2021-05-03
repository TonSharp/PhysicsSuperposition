using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : Dot
{
    private void Awake()
    {
        isMain = true;
        isProton = false;
    }
}
