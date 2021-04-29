using UnityEngine;

public class GridSpawner : MonoBehaviour, Spawner {
    public void Spawn(GlobalGrid grid){

        Vector3 TopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight,1));
        Vector3 TopRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1));
        Vector3 BottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1));
        Vector3 BottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 1));

        float width = TopRight.x - TopLeft.x;
        float height = TopLeft.y - BottomLeft.y;

        float offsetX = width/(grid.XCount + 1);
        float offsetY = height/(grid.YCount + 1);

        GameObject dot = Resources.Load<GameObject>("Prefabs/Dot");
        GameObject hor = Resources.Load<GameObject>("Prefabs/Horizon");

        for(var y = 0; y < grid.YCount; y++)
        {
            for(var x = 0; x < grid.XCount; x++)
            {
                GameObject temp = Instantiate(dot, GameObject.Find("DotHolder").transform);
                dot.GetComponent<SpriteRenderer>().enabled = false;
                dot.GetComponent<CircleCollider2D>().enabled = false;
                dot.transform.position = new Vector3(BottomLeft.x + ((x * offsetX) + offsetX), BottomLeft.y + ((y * offsetY) + offsetY), 0);
                dot.GetComponent<Dot>().grid = grid;
                dot.GetComponent<Dot>().isGrid = true;
                dot.GetComponent<LineRenderer>().startWidth = 0.1f;
                grid.Dots.Add(temp.GetComponent<Dot>());
            }

            GameObject tempHor = Instantiate(hor, GameObject.Find("HorHolder").transform);
            tempHor.transform.position = new Vector3(BottomLeft.x + offsetX, BottomLeft.y + ((y * offsetY) + offsetY), 0);
            tempHor.GetComponent<LineRenderer>().positionCount = grid.XCount;
            grid.Horizons.Add(tempHor.GetComponent<LineRenderer>());
        }
    }
}