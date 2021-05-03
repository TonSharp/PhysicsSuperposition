using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtonClick : MonoBehaviour
{
    private GameObject proton;
    private GameObject electron;

    private void Awake()
    {
        proton = Resources.Load<GameObject>("Prefabs/Proton");
        electron = Resources.Load<GameObject>("Prefabs/Electron");
    }
    private void AddToList(GameObject temp){
        GameObject.Find("GlobalGrid").GetComponent<GlobalGrid>().Dots.Add(temp.GetComponent<Dot>());
    }
    public void OnElectronSpawnClick(){
        GameObject temp = Instantiate(electron);
        AddToList(temp);
    }

    public void OnProtonSpawnClick(){
        GameObject temp = Instantiate(proton);
        AddToList(temp);
    }
}
