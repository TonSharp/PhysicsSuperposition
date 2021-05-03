using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMenuController : MonoBehaviour
{
    private GameObject gridMenu;
    private GameObject colorMenu;
    private GameObject arrowMenu;

    private GameObject activeObject;
    private bool isShowing = false;

    private void Awake()
    {
        gridMenu = Resources.Load<GameObject>("Prefabs/GridPanel");
        colorMenu = Resources.Load<GameObject>("Prefabs/ColorPanel");
        arrowMenu = Resources.Load<GameObject>("Prefabs/ArrowPanel");
    }
    private void DeleteOrCreateMenu(GameObject clicked){
        if(isShowing){
            isShowing = true;
            Destroy(activeObject);
            if(activeObject.tag != clicked.tag)
                activeObject = Instantiate(clicked, this.transform);
            else 
                isShowing = false;
        }
        else{
            isShowing = true;
            activeObject = Instantiate(clicked, this.transform);
        }
    }
    public void GridButtonClicked(){
        DeleteOrCreateMenu(gridMenu);
    }

    public void ColorButtonClicked(){
        DeleteOrCreateMenu(colorMenu);
    }

    public void ArrowButtonClicked(){
        DeleteOrCreateMenu(arrowMenu);
    }
}
