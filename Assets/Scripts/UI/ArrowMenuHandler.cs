using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMenuHandler : MonoBehaviour
{
    [SerializeField]
    private Slider length;
    [SerializeField]
    private Toggle isSame;
    void Start()
    {
        SettingsHandler sh = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();
        length.value = sh.MaxLength;
        isSame.isOn = !sh.IsSameLength;
    }
    public void UpdateArrowsLength()
    {
        SettingsHandler sh = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();
        sh.MaxLength = length.value;
    }
    public void UpdateArrowsSame()
    {
        SettingsHandler sh = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();
        sh.IsSameLength = !isSame.isOn;
    }
}
