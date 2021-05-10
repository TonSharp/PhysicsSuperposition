using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMenuHandler : MonoBehaviour
{
    [SerializeField]
    private Dropdown colorSwitch;
    [SerializeField]
    private Slider greenSlider, blueSlider, increaseSlider;
    void Start()
    {
        SettingsHandler sh = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();

        if(sh.IsColored) colorSwitch.value = 0;
        else colorSwitch.value = 1;

        greenSlider.value = sh.GreenBorder;
        blueSlider.value = sh.BlueBorder;
        increaseSlider.value = sh.MaxColorVal;
    }
    public void UpdateColor()
    {
        SettingsHandler sh = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();

        if(colorSwitch.value == 0) sh.IsColored = true;
        else sh.IsColored = false;
    }
    public void UpdateBorders()
    {
        SettingsHandler sh = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();

        sh.GreenBorder = greenSlider.value;
        sh.BlueBorder = blueSlider.value;
    }
    public void UpdateColorDensity()
    {
        SettingsHandler sh = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();

        sh.MaxColorVal = increaseSlider.value;
    }
}
