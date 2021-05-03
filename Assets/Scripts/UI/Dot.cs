using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO
//1. Add UI features
//2. Add extended drawings
//3. Add shapes support

public class Dot : MonoBehaviour
{
    public bool isMain;
    public bool isProton;
    public bool isGrid;

    [SerializeField]
    private float dS;

    [SerializeField]

    float width, height;
    public GlobalGrid grid;
    private Vector3 DiffPos;

    private void Awake()
    {
        grid = GameObject.Find("GlobalGrid").GetComponent<GlobalGrid>();
    }
    private void Update()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
        if(isMain)
            gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
    }
    private void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.Delete)){
            grid.Dots.Remove(this);
            GameObject.Destroy(gameObject);
        }
    }

    private void OnMouseEnter() 
    {
        gameObject.GetComponent<Outliner>().enabled = true;
    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<Outliner>().enabled = false;
    }

    private void OnMouseDown()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        DiffPos = new Vector3(MousePos.x - transform.position.x, MousePos.y - transform.position.y, 0);
    }

    private void OnMouseDrag() 
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(MousePos.x - DiffPos.x, MousePos.y - DiffPos.y, 0);
    }
    public void SetMainValue(bool val)
    {
        isMain = val;
    }
}