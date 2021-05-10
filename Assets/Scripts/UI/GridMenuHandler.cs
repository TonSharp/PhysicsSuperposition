using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMenuHandler : MonoBehaviour
{
    [SerializeField]
    private InputField XInput, YInput;

    void Start()
    {
        GlobalGrid gg = GameObject.Find("GlobalGrid").GetComponent<GlobalGrid>();
        XInput.text = gg.XCount.ToString();
        YInput.text = gg.YCount.ToString();
    }
    public void UpdateGrid()
    {
        GlobalGrid gg = GameObject.Find("GlobalGrid").GetComponent<GlobalGrid>();
        gg.XCount = System.Int32.Parse(XInput.text);
        gg.YCount = System.Int32.Parse(YInput.text);

        gg.UpdateGrid();
    }
}
