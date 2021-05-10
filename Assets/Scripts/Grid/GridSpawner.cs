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

        for(var y = 0; y < grid.YCount; y++)
        {
            for(var x = 0; x < grid.XCount; x++)
            {
                GameObject temp = Instantiate(dot, GameObject.Find("DotHolder").transform);
                dot.transform.position = new Vector3(BottomLeft.x + ((x * offsetX) + offsetX), BottomLeft.y + ((y * offsetY) + offsetY), 0);
                dot.GetComponent<Dot>().grid = grid;
                grid.Dots.Add(temp.GetComponent<Dot>());
            }
        }
    }
    public void Respawn(GlobalGrid grid)
    {
        GameObject DotParrent = GameObject.Find("DotHolder");
        int childCount = DotParrent.transform.childCount;

        for(int i = 0; i < childCount; i++){
            GameObject child = DotParrent.transform.GetChild(i).gameObject;
            grid.Dots.Remove(child.GetComponent<Dot>());
            Destroy(child);
        }

        Spawn(grid);
    }
}