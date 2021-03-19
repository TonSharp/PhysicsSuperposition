using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public DotHolder holder;

    private void OnMouseDown()
    {
        holder.ChangeActiveStates(null);
    }
}
