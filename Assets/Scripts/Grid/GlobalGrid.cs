using System;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGrid : MonoBehaviour {
    public List<Dot> Dots = new List<Dot>();
    public List<LineRenderer> Horizons = new List<LineRenderer>();
    public List<Drawer> Drawers = new List<Drawer>();
    public Spawner spawner = new GridSpawner();
    public int XCount = 35;
    public int YCount = 35;
    public float MaxPredicate = 1;
    public float MaxLength;
    public int DotOffset;

    private void Awake()
    {
        DotOffset = Dots.Count;
    } 
    private void Start()
    {
        spawner.Spawn(this);
        Drawers.Add(new LineDrawer());
    }
    private void Update()
    {
        foreach(var a in Drawers){
            a.Draw(this);
        }
    }
}