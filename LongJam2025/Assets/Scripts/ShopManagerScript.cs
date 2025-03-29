using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[13,13];
    public float points;
    public float quantity;
    public TMP_Text PointsTxt;

    
    void Start()
    {
       PointsTxt.text = points.ToString();

       shopItems[1,1] = 1;
       shopItems[1,2] = 2;
       shopItems[1,3] = 3;
       shopItems[1,4] = 4;
       shopItems[1,5] = 5;
       shopItems[1,6] = 6;
       shopItems[1,7] = 7;
       shopItems[1,8] = 8;
       shopItems[1,9] = 9;
       shopItems[1,10] = 10;
       shopItems[1,11] = 11;
       shopItems[1,12] = 12;

       // Preços

       shopItems[2,1] = 10;
       shopItems[2,2] = 20;
       shopItems[2,3] = 30;
       shopItems[2,4] = 40;
       shopItems[2,5] = 50;
       shopItems[2,6] = 60;
       shopItems[2,7] = 70;
       shopItems[2,8] = 80;
       shopItems[2,9] = 90;
       shopItems[2,10] = 100;
       shopItems[2,11] = 120;
       shopItems[2,12] = 130;

       //Quantidade
       for(int i=1;i<13;i++){
        shopItems[3,i] = 0;
       }


    }

   
    public void Buy()
    {
        
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (points >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemId]){
            points -= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemId];
           shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemId] += 1 ;

             PointsTxt.text = points.ToString();
             print("Item " + ButtonRef.GetComponent<ButtonInfo>().ItemId + " comprado com sucesso!" );
             
        }
        else{
            print("Voce nao possui pontos suficientes para comprar o item " + ButtonRef.GetComponent<ButtonInfo>().ItemId + "!" );
        }
    
    
    }
}
