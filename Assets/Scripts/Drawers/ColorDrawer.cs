using UnityEngine;

public class ColorDrawer : Drawer {
    public void Draw(GlobalGrid Grid){
        foreach(var a in Grid.Dots){
            TensionHelper.CalculateTensionVector(a, Grid.Dots, out float val);
            byte presents = (byte)(val / Grid.MaxPredicate);
            a.GetComponent<LineRenderer>().startColor = new Color32(presents, presents, presents, byte.MaxValue);
            a.GetComponent<LineRenderer>().endColor = new Color32(presents, presents, presents, byte.MaxValue);
        }
    }
}