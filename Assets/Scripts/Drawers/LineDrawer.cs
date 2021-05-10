using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : Drawer
{
    private SettingsHandler settingsHandler = GameObject.Find("SettingsHandler").GetComponent<SettingsHandler>();
    private Color ColorFromInt(float a){
        var blue = a / 65536;
        var green = (a - blue * 65536) / 256;
        var red = a - blue * 65536 - green * 256;

        return new Color(blue, green, red);
    }
    public void Draw(GlobalGrid Grid)
    {
        if(settingsHandler.IsPrivateLines){

            foreach(var a in Grid.Dots){
                
                if(a.isMain) continue;

                Vector2 Dest = TensionHelper.CalculateTensionVector(a, Grid.Dots, out float val);
                a.GetComponent<LineRenderer>().SetPosition(1, Dest);

                if(settingsHandler.IsColored)
                {
                    val /= settingsHandler.MaxColorVal;
                    float presents;

                    if(val >= settingsHandler.GreenBorder)
                    {
                        presents = val / settingsHandler.GreenBorder;

                        a.GetComponent<LineRenderer>().startColor = new Color(presents - settingsHandler.GreenBorder, 1/presents, 0);
                        a.GetComponent<LineRenderer>().endColor = new Color(presents - settingsHandler.GreenBorder, 1/presents, 0);
                    }
                    else if(val < settingsHandler.GreenBorder && val >= settingsHandler.BlueBorder)
                    {
                        presents = val / settingsHandler.BlueBorder;

                        a.GetComponent<LineRenderer>().startColor = new Color(0, val/settingsHandler.GreenBorder, 1/presents);
                        a.GetComponent<LineRenderer>().endColor = new Color(0, val/settingsHandler.GreenBorder, 1/presents);
                    }
                    else 
                    {
                        presents = val / settingsHandler.BlueBorder;
                        if(presents < 0.5f) presents = 0.5f;

                        a.GetComponent<LineRenderer>().startColor = new Color(1 - presents, 0, presents);
                        a.GetComponent<LineRenderer>().endColor = new Color(1 - presents, 0, presents);

                    }
                }
                else
                {
                    val /= settingsHandler.MaxColorVal;
                    a.GetComponent<LineRenderer>().startColor = new Color(val, val, val);
                    a.GetComponent<LineRenderer>().endColor = new Color(val, val, val);
                }
            }
        }
        else if(!settingsHandler.IsPrivateLines){
            foreach(var a in Grid.Dots){
                a.GetComponent<LineRenderer>().enabled = false;
            }
        }
        if(settingsHandler.IsHorizontalLines){
            for(int j = 0; j < Grid.Horizons.Count; j++){
                for(int i = 0; i < Grid.XCount; i++){
                    Vector2 Dest = new Vector2();
                    if(j + 1 == Grid.Horizons.Count)
                        Dest = TensionHelper.CalculateTensionVector(Grid.Dots[Grid.Dots.Count - 1], Grid.Dots, out float val);
                    else
                        Dest = TensionHelper.CalculateTensionVector(Grid.Dots[Grid.DotOffset + 1 + Grid.XCount * j + i], Grid.Dots, out float val);
                    Grid.Horizons[j].SetPosition(i, Dest);
                }
            }
        }
    }
}