using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    public static bool IsColored = false;
    public static bool IsHorizontalLines = false;
    public static bool IsPrivateLines = true;
    public static bool IsSameLength = false;
    public static bool IsGrid = true;
    public static float Power = 0.0000000001f;

    public bool _IsColored = false;
    public bool _IsHorizontalLines = false;
    public bool _IsPrivateLines = true;
    public bool _IsSameLength = false;
    public bool _IsGrid = true;
    public float _Power;

    private void Awake()
    {
        Power = _Power;  
        IsColored = _IsColored;
        IsHorizontalLines = _IsHorizontalLines;
        IsPrivateLines = _IsPrivateLines;
        IsSameLength = _IsSameLength;
        IsGrid = _IsGrid;
    }
}
