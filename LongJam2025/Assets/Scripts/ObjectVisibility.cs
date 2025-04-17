using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    SpriteRenderer sprite;
    public int ItemId;
    public int UpgradeId;
    public GameObject ShopManager;

    private void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
    void Update()
    {
        if(ShopManager.GetComponent<ShopManagerScript>().shopItems[4,ItemId] == 1){
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
        if (UpgradeId > 0)
        {
            if (ShopManager.GetComponent<ShopManagerScript>().shopItems[4, UpgradeId] == 1)
            {
                sprite.enabled = false;
            }
        }
    }
}

