using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGrid : MonoBehaviour
{
    [SerializeField]
    DotHolder holder;

    [SerializeField]
    private int GridX = 5, GridY = 5;
    private GameObject dot;
    void Start()
    {
        Vector3 TopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight,1));
        Vector3 TopRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1));
        Vector3 BottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1));
        Vector3 BottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 1));

        float width = TopRight.x - TopLeft.x;
        float height = TopLeft.y - BottomLeft.y;

        float offsetX = width/(GridX + 1);
        float offsetY = height/(GridY + 1);

        dot = Resources.Load<GameObject>("Prefabs/Dot");

        for(var y = 0; y < GridY; y++)
        {
            for(var x = 0; x < GridX; x++)
            {
                GameObject temp = Instantiate(dot);
                dot.GetComponent<SpriteRenderer>().enabled = false;
                dot.GetComponent<CircleCollider2D>().enabled = false;
                dot.transform.position = new Vector3(BottomLeft.x + ((x * offsetX) + offsetX), BottomLeft.y + ((y * offsetY) + offsetY), 0);
                //dot.GetComponent<Dot>().holder = holder;
                dot.GetComponent<Dot>().isGrid = true;
                dot.GetComponent<LineRenderer>().startWidth = 0.1f;
                holder.Dots.Add(temp.GetComponent<Dot>());
            }
        }
    }
}
