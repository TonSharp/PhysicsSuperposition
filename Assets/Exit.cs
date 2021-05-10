using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitApp()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
