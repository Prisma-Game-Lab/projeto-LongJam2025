using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : ObjectScript
{
    [SerializeField] private GameObject item;

    public void createBox()
    {
        Instantiate(item, new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 0), Quaternion.identity);
    }
}
