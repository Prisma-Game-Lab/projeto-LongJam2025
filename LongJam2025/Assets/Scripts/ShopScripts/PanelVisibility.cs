using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVisibility : MonoBehaviour
{
public GameObject panelA;
   public GameObject panelB;
    public GameObject panelC;

public GameObject button2;
public GameObject button3;
    public bool a = true;
    public bool b = false;
    public bool c = false;
    public GameObject ShopManager;
    // Start is called before the first frame update
    void Start()
    {
    panelA.SetActive(a);
    panelB.SetActive(b);
    panelC.SetActive(c); 
    }

public void Tier1(){
    
    if (a == false){
        a = !a;
        b = false;
        c = false;
        panelA.SetActive(a);
        panelB.SetActive(b);
        panelC.SetActive(c); 
    
}

}

public void Tier2(){
    if (ShopManager.GetComponent<ShopManagerScript>().total_points >= 1500){
    if (b == false){
        b = !b;
        a = false;
        c = false;
        panelA.SetActive(a);
        panelB.SetActive(b);
        panelC.SetActive(c); 
    }
}
else{
    
}
}
public void Tier3(){
    if (ShopManager.GetComponent<ShopManagerScript>().total_points >= 45000){
    if (c == false){
        c = !c;
        a = false;
        b = false;
        panelA.SetActive(a);
        panelB.SetActive(b);
        panelC.SetActive(c); 
    }
}
else{
    
}
  
}
    public void Update()
    {
       if (ShopManager.GetComponent<ShopManagerScript>().total_points >= 1500){
        button2.SetActive(false);
       }
       if (ShopManager.GetComponent<ShopManagerScript>().total_points >= 45000){
        button3.SetActive(false);
       }
    }
}
