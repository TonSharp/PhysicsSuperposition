using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public bool isMain = false;
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

    private void Awake()
    {
        Panel = Resources.Load<GameObject>("Prefabs/Setup panel");
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