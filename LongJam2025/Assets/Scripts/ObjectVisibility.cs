using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    public GameObject item;

   
    public int ItemId;
  
    public GameObject ShopManager;
    
	
    void Update()
    {
    

     if(ShopManager.GetComponent<ShopManagerScript>().shopItems[4,ItemId] == 1){
        item.SetActive(true);
    }
    if(ShopManager.GetComponent<ShopManagerScript>().shopItems[4,ItemId] == 0){
        item.SetActive(false);
    }
    }
    }

