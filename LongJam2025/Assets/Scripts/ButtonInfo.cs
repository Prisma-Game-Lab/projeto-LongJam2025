using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{

public int ItemId;
public TMP_Text PriceText;

public GameObject ShopManager;
    // Update is called once per frame
    void Update()
    {
      PriceText.text = "$" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2,ItemId].ToString(); 
    }
}
