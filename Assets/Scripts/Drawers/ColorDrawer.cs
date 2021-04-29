using UnityEngine;

public class ColorDrawer : Drawer {
    public void Draw(GlobalGrid Grid){
        foreach(var a in Grid.Dots){
            TensionHelper.CalculateTensionVector(a, Grid.Dots, out float val);
            float presents = val / Grid.MaxPredicate;
            if(presents > 1) presents = 1;
            a.GetComponent<LineRenderer>().startColor = new Color(presents,0,1 - presents);
            a.GetComponent<LineRenderer>().endColor = new Color(presents,0,1 - presents);
        }
    }
}