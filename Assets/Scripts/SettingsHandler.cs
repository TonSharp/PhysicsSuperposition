using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    public bool IsColored = true;
    public bool IsHorizontalLines = false;
    public bool IsPrivateLines = true;
    public bool IsSameLength = false;
    public bool IsGrid = true;
    public float Power = 0.0000000001f;
    public float MaxLength = 1f;

    public float MaxColorVal = 500f;
    public float GreenBorder = 100f;
    public float BlueBorder = 50f;
    private void Awake()
    {
    }
}
