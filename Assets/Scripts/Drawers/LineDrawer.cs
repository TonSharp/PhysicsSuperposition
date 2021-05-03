using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : Drawer
{
    public void Draw(GlobalGrid Grid)
    {
        if(SettingsHandler.IsPrivateLines){

            foreach(var a in Grid.Dots){
                
                if(a.isMain) continue;

                Vector2 Dest = TensionHelper.CalculateTensionVector(a, Grid.Dots, out float val);
                a.GetComponent<LineRenderer>().SetPosition(1, Dest);

                if(SettingsHandler.IsColored)
                {
                    float presents = val / Grid.MaxPredicate;
                    if(presents > 1) presents = 1;
                    a.GetComponent<LineRenderer>().startColor = new Color(presents,0,1 - presents);
                    a.GetComponent<LineRenderer>().endColor = new Color(presents,0,1 - presents);
                }
            }
        }
        else if(!SettingsHandler.IsPrivateLines){
            foreach(var a in Grid.Dots){
                a.GetComponent<LineRenderer>().enabled = false;
            }
        }
        if(SettingsHandler.IsHorizontalLines){
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