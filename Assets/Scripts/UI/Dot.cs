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
    public bool isMain = false;
    public bool isProton = false;
    private bool isActive = false;

    [SerializeField]
    private float dS;

    [SerializeField]

    float width, height;
    [SerializeField]
    private DotHolder holder;

    private Vector3 DiffPos;
    private GameObject Panel;
    private GameObject panelTemp;

    private float tension
    {
        get {
            float val;
            TensionHelper.CalculateTensionVector(this, holder.Dots, holder.power, out val);
            return val;
        }
    }

    private void Awake()
    {
        Panel = Resources.Load<GameObject>("Prefabs/Setup panel");
    }

    private void Update()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
        if(isMain) gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
    }

    private void OnMouseEnter() 
    {
        gameObject.GetComponent<Outliner>().enabled = true;
    }

    private void OnMouseOver()
    {
        if(!isMain)
            GameObject.Find("Tension num").GetComponent<Text>().text = tension + " В/м";
    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<Outliner>().enabled = false;

        if(!isMain)
            GameObject.Find("Tension num").GetComponent<Text>().text = "0 В/м";
    }

    private void OnMouseDown()
    {
        if(!isActive)
        {
            isActive = true;
            panelTemp = Instantiate(Panel, new Vector2(transform.position.x + width, transform.position.y + height), new Quaternion(), GameObject.Find("Canvas").transform);
            holder.ChangeActiveStates(gameObject);

            panelTemp.GetComponentInChildren<SetupPanel>().parent = gameObject;
        }
        else DisableActive();



        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        DiffPos = new Vector3(MousePos.x - transform.position.x, MousePos.y - transform.position.y, 0);
    }

    private void OnMouseDrag() 
    {
        if(panelTemp) panelTemp.transform.position = new Vector2(transform.position.x + width, transform.position.y + height);

        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(MousePos.x - DiffPos.x, MousePos.y - DiffPos.y, 0);
    }
    public void DisableActive()
    {
        isActive = false;

        Destroy(panelTemp);
    }
    public void SetMainValue(bool val)
    {
        isMain = val;
    }
}