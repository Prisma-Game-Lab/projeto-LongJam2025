using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : ObjectScript
{
    [SerializeField] private GameObject item;
    [SerializeField] private ShopManagerScript shop;

    public void createBox()
    {
        Instantiate(item, new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 0), Quaternion.identity);
    }
    public void earnPoints()
    {
        shop._points += 5 + GameManager.tier * 10;
        shop.total_points += 5 + GameManager.tier * 10;
    }

}
