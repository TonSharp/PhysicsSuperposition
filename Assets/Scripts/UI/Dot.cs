using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMover : MonoBehaviour
{
    [SerializeField]
    private float dS;
    private Vector3 DiffPos;
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
        Debug.Log(DiffPos);
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(MousePos.x - DiffPos.x, MousePos.y - DiffPos.y, 0);
    }
}