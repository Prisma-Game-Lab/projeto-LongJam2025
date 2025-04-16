using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovelManager : MonoBehaviour
{
    public bool Placed { get; private set; }
    public BoundsInt area;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanBePlaced()
    {
        Vector3Int positionInt = GridManager.instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridManager.instance.CanTakeArea(areaTemp))
        {
            return true;
        }
        return false;
    }

    public void Place()
    {
        Vector3Int positionInt = GridManager.instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        Placed = true;
        GridManager.instance.TakeArea(areaTemp);
    }
}
