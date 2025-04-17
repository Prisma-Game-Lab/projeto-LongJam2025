using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
  public Canvas shop;
  public GameObject ShopManager;

  public bool isVisible = true;
    	void Start()
	{
	shop = GetComponent<Canvas> ();
    shop.enabled = false;
   

	}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
       shop.enabled = !shop.enabled;
       ShopManager.GetComponent<ShopManagerScript>().isVisible = !ShopManager.GetComponent<ShopManagerScript>().isVisible;
        }
        
    }

}

